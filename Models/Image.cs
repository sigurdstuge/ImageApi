using ImageApi.Interfaces;

namespace ImageApi.Models;

public class Image : IImage
{
	public int Id {get; set;}
	public string Name {get; set;}
	public string Place { get; set;}
	public int Year { get; set;}
	public string Img { get; set; }
}