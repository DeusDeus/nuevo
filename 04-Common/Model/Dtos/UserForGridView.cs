using System.Collections.Generic;

namespace Model.Dtos
{
    public class UserForGridView
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
