<Query Kind="Program" />

void Main()
{
	//Write a program to make a string quack
	string result = "Bob".Quack();
	int size = result.Length;
	
	result.Dump("here is the result");
	size.Dump("Here is the string length of this");
}

// Define other methods and classes here
public static class StringExtensions
{
	public static string Quack(this string self)
	{
	
		return self = " (quack)";
	
	
	}


}