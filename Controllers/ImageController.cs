using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ImageApi.Contexts;
using ImageApi.Models;

namespace ImageApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ImageController : ControllerBase
{
	private readonly ImageContext _imageContext;
	public ImageController(ImageContext imageContext)
	{
		_imageContext = imageContext;
	}


	[HttpGet]
	public async Task<ActionResult<Image>> Get()
	{
		try
		{
			 List<Image> images = await _imageContext.images.ToListAsync();
            return Ok (images);
		}
		catch
		{
			return StatusCode(StatusCodes.Status500InternalServerError);
		}


	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Image?>> Get(int id) 
	{
		try
		{
			 	Image? image = await _imageContext.images.FindAsync(id);
            return image;
		}
		catch
		{
			return StatusCode(StatusCodes.Status500InternalServerError);
		}
	}

	[HttpPost]
	public async Task<ActionResult<Image>> Post(Image newImage)
	{
		try
		{
			_imageContext.images.Add(newImage);
			await _imageContext.SaveChangesAsync();
			return Created();
		}
		catch
		{
			return StatusCode(StatusCodes.Status500InternalServerError);
		}
	}



	[HttpDelete("id")]
	public async Task<ActionResult<Image>> Delete(int id)
	{
		try
		{
			Image? imageToDelete = await _imageContext.images.FindAsync(id);
			if(imageToDelete != null)
			{
				_imageContext.images.Remove(imageToDelete);
				await _imageContext.SaveChangesAsync();
				return imageToDelete;
			}
			else
			{
				return NotFound();
			}
		}
		catch
		{
			return StatusCode(StatusCodes.Status500InternalServerError);
		}
	}
}
