namespace TrafficBackendAPI.UserModule.Utilities
{
    internal static class ResponseMessageHelper
    {
        public static string ServiceCommandMessage(int code)
        {
            string message = string.Empty;

            switch (code)
            {
                case 1:
                    message = "Data has been saved.";
                    break;
                case 2:
                    message = "Data has not been saved.";
                    break;
                case 3:
                    message = "Data has been updated.";
                    break;
                case 4:
                    message = "Data has not been updated.";
                    break;
                case 5:
                    message = "Data has been deleted.";
                    break;
                case 6:
                    message = "Data has not been deleted.";
                    break;
                default:
                    break;

            }

            return message;
        }

        public static string ServiceQueryMessage(int code)
        {
            string message = string.Empty;

            switch (code)
            {
                case 1:
                    message = "Data has been fetched.";
                    break; 
                case 2:
                    message = "No data found.";
                    break;
                default:
                    break;
            }

            return message;
        }
    }
}
