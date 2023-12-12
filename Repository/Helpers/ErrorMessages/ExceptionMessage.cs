using System;
namespace Repository.Helpers.ErrorMessages
{
	public static class ExceptionMessage
	{
		public static string NotFoundMessage { get; set; } = "Data Not Found";
        public static string ArgumentNullMessage { get; set; } = "Argument is null";
        public static string LoginMessage { get; set; } = "Email or Password is wrong";


    }
}

