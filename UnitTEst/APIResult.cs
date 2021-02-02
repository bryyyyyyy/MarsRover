using System;
using Xunit;
using Enterprise;
using Domain;

namespace APIResult
{
	public class APIResult
	{
		[Theory]
		[InlineData("June 2, 2018")]
		[InlineData("02/27/17")]
		[InlineData("Jul-13-2016")]
		
		public void CorrectParams(string date)
		{
			MarsRoverService svc = new MarsRoverService();
			BaseService baseSvc = new BaseService();
			Response response = new Response();

			string parsedDate= baseSvc.parseDate(date);
			if (parsedDate != "01/01/0001") response = svc.GetMarsRorverPhoto(parsedDate);

			Assert.True(response.photos != null && response.photos.Count > 0);
		}

		[Theory]
		[InlineData("asdfasdf")]
		[InlineData("123453245")]
		public void IncorrectParams(string date)
		{
			MarsRoverService svc = new MarsRoverService();
			BaseService baseSvc = new BaseService();
			Response response = new Response();

			string parsedDate = baseSvc.parseDate(date);
			if (parsedDate != "01/01/0001") response = svc.GetMarsRorverPhoto(parsedDate);

			Assert.True(response.photos == null || response.photos.Count < 1);
		}

		[Theory]
		[InlineData("April 31, 2018")]
		[InlineData("02/31/2020")]
		[InlineData("13/01/2020")]
		public void IncorrectDateParams(string date)
		{
			MarsRoverService svc = new MarsRoverService();
			BaseService baseSvc = new BaseService();
			Response response = new Response();

			string parsedDate = baseSvc.parseDate(date);
			if (parsedDate != "01/01/0001") response = svc.GetMarsRorverPhoto(parsedDate);

			Assert.True(response.photos == null || response.photos.Count < 1);
		}
	}
}