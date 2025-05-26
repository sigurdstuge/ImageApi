namespace ImageApi.Interfaces;

public interface IImage
{
	int Id {get; set;}
	string Name {get; set;}
	string Place { get; set;}
	int Year { get; set;}
	string Img {get; set;}
}