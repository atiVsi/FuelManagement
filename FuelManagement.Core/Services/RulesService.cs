using FuelManagement.Core.Dtos.Rules;
using FuelManagement.Core.Services.Interface;
using FuelManagement.Core.Convertors;
using FuelManagement.DataLayer.Entities.Rules;
using FuelManagement.DataLayer.Context;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Services
{
    public class RulesService : RepositoryBase<long, Rules>, IRulesService
    {
        private readonly FuelmanagementContext _context;

        public RulesService(FuelmanagementContext context) : base(context)
        {
            _context = context;
        }

        public bool Add(CreateNewRule rule)
        {
            try
            {
                var imageUrl = new List<string>();
                var fileExtension = "";

                foreach (var image in rule.RuleImage)
                {

                    fileExtension = Path.GetExtension(image.FileName).Remove(0, 1);
                    var extension = image.ContentType;

                    var base64 = "";
                    string fileContent = "";
                    using (var reader = new StreamReader(image.OpenReadStream()))
                    {
                        fileContent = reader.ReadToEnd();

                    }
                    using (var stream = new MemoryStream())
                    {
                        image.CopyTo(stream);
                        var bytes = stream.ToArray();
                        base64 = Convert.ToBase64String(bytes);
                    }
                    //var urlImage = ImageService.AddToFile(rule.Title + " " + rule.Title, rule.Description + " " + rule.Description,
                    //rule.Description + " " + rule.Title, base64, extension, fileExtension);

                    //imageUrl.Add(urlImage);

                }




                var newsImageStr = string.Join(",", imageUrl);




                var query = new Rules(rule.Title, rule.Description, newsImageStr, rule.Userlog, fileExtension);
                Create(query);
                SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        private string ConvertImageToBase64(IFormFile image)
        {
            using (var memoryStream = new MemoryStream())
            {
                image.CopyTo(memoryStream);
                var bytes = memoryStream.ToArray();
                return Convert.ToBase64String(bytes);
            }
        }



        private DateTime ConvertShamsiToGregorian(string shamsiDate)
        {
            var persianCalendar = new PersianCalendar();

            // فرض بر اینکه فرمت ورودی "yyyy/MM/dd" یا "yyyy-MM-dd" است
            var parts = shamsiDate.Split(new[] { '/', '-' });

            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int day = int.Parse(parts[2]);

            return persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
        }


        public List<ListRulesDto> GetAll(string search)
        {
            return _context.Rules
                    .Where(x => x.Title.Contains(search))
                    .OrderByDescending(x => x.Id)
                    .Select(x => new ListRulesDto
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Description = x.Description,
                        Creationdate = x.CreationDate.ToShamsi(),
                        Userlog = x.UserLog,
                        IsDelete = x.IsDelete,
                        RuleImage = x.RuleImage,
                        FileType = x.FileType,
                    })
                    .ToList();
        }



        public DetailRulesDto GetDetail(long id)
        {
            var rules = _context.Rules.FirstOrDefault(n => n.Id == id);
            if (rules == null)
                return null;

            return new DetailRulesDto
            {
                Title = rules.Title,
                Description = rules.Description,
                RuleImage = string.IsNullOrWhiteSpace(rules.RuleImage)
                    ? new List<string>()
                    : rules.RuleImage.Split(',').ToList(),

                Creationdate = rules.CreationDate.ToShamsi(),
                Userlog = rules.UserLog,
                IsDelete = rules.IsDelete,
            };

        }

        public bool Remove(long id, string userLog)
        {
            try
            {
                var removerules = _context.Rules.FirstOrDefault(n => n.Id == id);
                if (removerules == null)
                {
                    return false;
                }
                removerules.Remove(userLog);
                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}