#nullable disable
using Microsoft.EntityFrameworkCore;
using ImageApi.Models;

namespace ImageApi.Contexts;

public class ImageContext : DbContext
{
	public ImageContext(DbContextOptions<ImageContext> options):base(options){}

	public DbSet<Image> images {get; set;}
}