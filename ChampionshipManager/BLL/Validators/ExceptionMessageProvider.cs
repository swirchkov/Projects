using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validators
{
    internal static class ExceptionMessageProvider
    {
        public static KeyValuePair<string, string> ID_NOT_FOUND_IN_DATABASE { get; } =
            new KeyValuePair<string, string>("Id", "No object with given id in database");

        public static KeyValuePair<string, string> ID_EXISTS_IN_DATABASE { get; } =
            new KeyValuePair<string, string>("Id", "Object with given id found in database");

        public static KeyValuePair<string, string> FOREIGN_KEY_PROBLEMS { get; } =
            new KeyValuePair<string, string>("{Entity}Id", "Cannot find related entity with given id");

        public static KeyValuePair<string, string> ZERO_TOURNAMENT_PARTICIPATES_MESSAGE { get; } =
            new KeyValuePair<string, string>("ParticipateNumber", "Tournament must have some number of participates");

        public static KeyValuePair<string, string> NULL_VALUE_MESSAGE { get; } =
            new KeyValuePair<string, string>("{Field}", "Value cannot be null or empty ");

        public static KeyValuePair<string, string> INVALID_EMAIL { get; } =
            new KeyValuePair<string, string>("Email", "Invalid email format");

        public static KeyValuePair<string, string> TOURNAMENT_ALREADY_STARTS { get; } =
            new KeyValuePair<string, string>("tournamentId", "Tournament had started so you can't make request to participate in it.");
    }
}
