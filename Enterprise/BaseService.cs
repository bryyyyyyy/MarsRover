using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Domain;
using System.Globalization;

namespace Enterprise
{
	public class BaseService
	{
		private MarsRoverService marsRoverSvc;

		public Response readTextFile()
		{
			marsRoverSvc = new MarsRoverService();

			if (!File.Exists(Path.Combine(Environment.CurrentDirectory, @"Files\", "DateCaptured.txt"))) 
				return new Response();

			string[] lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Files\", "DateCaptured.txt"));
			Response _resp = new Response();
			_resp.photos = new List<Photo>();

			foreach (string line in lines)
			{
				string parsedDate = parseDate(line);
				
				Response response = marsRoverSvc.GetMarsRorverPhoto(parsedDate);

				if (response.photos != null && response.photos.Count > 0)
					_resp.photos.Add(response.photos[0]);
			}

			return _resp;
		}

		public string parseDate(string date)
		{
			try
			{
				DateTime parsedDate;
				DateTime.TryParse(date, out parsedDate);

				return parsedDate.ToString("yyyy-MM-dd");
			}
			catch (Exception ex)
			{
				return ex.Message.ToString();
			}
			
		}

	}
}
