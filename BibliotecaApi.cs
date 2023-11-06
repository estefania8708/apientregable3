using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace biblioteca.Controllers
{
    [Route("api/v1/libros")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private static List<Libro> libros = new List<Libro>();

        [HttpPost]
        public ActionResult CrearLibro(Libro nuevoLibro)
        {
            nuevoLibro.Id = Guid.NewGuid();
            libros.Add(nuevoLibro);
            return StatusCode(201); 

        [HttpGet("{id}")]
        public ActionResult<Libro> ObtenerLibroPorId(Guid id)
        {
            var libro = libros.Find(l => l.Id == id);
            if (libro == null)
            {
                return NotFound(); 
            }
            return Ok(libro); 
        }

        [HttpPut("{id}")]
        public ActionResult ActualizarLibro(Guid id, Libro libroActualizado)
        {
            var libro = libros.Find(l => l.Id == id);
            if (libro == null)
            {
                return NotFound(); 
            }

            libro.Titulo = libroActualizado.Titulo;
            libro.Resumen = libroActualizado.Resumen;
            libro.AutorId = libroActualizado.AutorId;

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarLibro(Guid id)
        {
            var libro = libros.Find(l => l.Id == id);
            if (libro == null)
            {
                return NotFound(); 
            }

            libros.Remove(libro);
            return NoContent(); 
        }
    }

    [Route("api/v1/autores")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private static List<Autor> autores = new List<Autor>();

        }

        [ApiController]
        [Route("api/[controller]")]

        public class AutoresController : ControllerBase
        {
            private List<Autor> _autores = new List<Autor>();

            [HttpGet]
            public ActionResult<IEnumerable<Autor>> ObtenerTodos()
            {
                return Ok(_autores);
            }

            [HttpGet("{id}")]
            public ActionResult<Autor> ObtenerPorId(Guid id)
            {
                var autor = _autores.FirstOrDefault(a => a.Id == id);
                if (autor == null)
                {
                    return NotFound();
                }
                return Ok(autor);
            }

            [HttpPost]
            public ActionResult<Autor> CrearAutor(Autor nuevoAutor)
            {
                nuevoAutor.Id = Guid.NewGuid();
                _autores.Add(nuevoAutor);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoAutor.Id }, nuevoAutor);
            }

            [HttpPut("{id}")]
            public IActionResult ActualizarAutor(Guid id, Autor autorActualizado)
            {
                var autorExistente = _autores.FirstOrDefault(a => a.Id == id);
                if (autorExistente == null)
                {
                    return NotFound();
                }

                autorExistente.Nombre = autorActualizado.Nombre;
                autorExistente.Nacionalidad = autorActualizado.Nacionalidad;

                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult EliminarAutor(Guid id)
            {
                var autor = _autores.FirstOrDefault(a => a.Id == id);
                if (autor == null)
                {
                    return NotFound();
                }

                _autores.Remove(autor);
                return NoContent();
            }
        }

    }

