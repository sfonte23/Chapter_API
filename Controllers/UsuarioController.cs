﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Chapter.Interfaces;
using Chapter.Models;
using Chapter.Repositories;

namespace Chapter.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
       private readonly IUsuarioRepository _iUsuarioRepository;  

        public UsuarioController (IUsuarioRepository usuarioRepository)
        {
            _iUsuarioRepository = usuarioRepository;
        }

        [HttpGet]

        public IActionResult Listar()
        {
            try
            {
                return Ok(_iUsuarioRepository.Listar());
            }

            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)

        {
            try
            {
                Usuario UsuarioEncontrado = _iUsuarioRepository.BuscarporId(id);

                if (UsuarioEncontrado == null)
                    return NotFound();
                return Ok(UsuarioEncontrado);   
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpPost]

        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                _iUsuarioRepository.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Usuario usuario)
        {
            try
            {
                Usuario usuarioBuscado = _iUsuarioRepository.BuscarporId(id);
                if(usuarioBuscado == null)
                {
                    return NotFound();

                }
                _iUsuarioRepository.Atualizar(id, usuario);
                return StatusCode(201);

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            try
            {
                Usuario usuarioBuscado = _iUsuarioRepository.BuscarporId(id);

                if(usuarioBuscado == null)
                {
                    return NotFound();

                }
                _iUsuarioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }

}
