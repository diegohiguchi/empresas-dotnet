using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using empresas_dotnet.Domain.Entities;
using empresas_dotnet.Domain.Interfaces;
using empresas_dotnet.Extensions;
using empresas_dotnet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace empresas_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : MainController
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsuariosController(INotificador notificador,
                              UserManager<ApplicationUser> userManager) : base(notificador)
        {
            _userManager = userManager;
        }

        [HttpPost("lista-administradores")]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<ApplicationUser>> ObterTodosAdministradores(PaginacaoViewModel paginacao)
        {
            var adminsitradores = await _userManager.GetUsersInRoleAsync("Admin");
            adminsitradores = adminsitradores.Skip((paginacao.PageNumber - 1) * paginacao.PageSize).Take(paginacao.PageSize).ToList();

            return adminsitradores.Where(x => x.Active).ToList().OrderBy(x=> x.UserName);
        }
        
        [HttpPost("lista-usuarios")]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<ApplicationUser>> ObterTodosUsuarios(PaginacaoViewModel paginacao)
        {
            var usuarios = await _userManager.GetUsersInRoleAsync("Usuario");
            usuarios = usuarios.Skip((paginacao.PageNumber - 1) * paginacao.PageSize).Take(paginacao.PageSize).ToList();

            return usuarios?.Where(x => x.Active).ToList().OrderBy(x => x.UserName);
        }

        [HttpGet("lista-usuarios")]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<ApplicationUser>> ObterTodosUsuarios()
        {
            var usuarios = await _userManager.GetUsersInRoleAsync("Usuario");

            return usuarios.Where(x => x.Active).ToList().OrderBy(x => x.UserName);
        }

        [HttpPost("editar")]
        [Authorize(Roles = "Admin,Usuario")]
        public async Task<ActionResult<ApplicationUser>> Editar(UsuarioViewModel usuarioViewModel)
        {
            var usuario = await _userManager.FindByIdAsync(usuarioViewModel.Id);
            usuario.UserName = usuarioViewModel.UserName;
            usuario.Email = usuarioViewModel.Email;

            await _userManager.UpdateAsync(usuario);

            return CustomResponse();
        }

        [HttpPost("excluir")]
        [Authorize(Roles = "Admin,Usuario")]
        public async Task<ActionResult<ApplicationUser>> Excluir(Guid usuarioId)
        {
            var usuario = await _userManager.FindByIdAsync(usuarioId.ToString());
            usuario.Active = false;

            await _userManager.UpdateAsync(usuario);

            return CustomResponse();
        }
    }
}
