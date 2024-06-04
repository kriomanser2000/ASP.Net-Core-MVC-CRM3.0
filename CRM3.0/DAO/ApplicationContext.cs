using CRM3._0.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CRM3._0.DAO
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Config> Configs { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<MiscData> MiscData { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ContactLog> ContactLogs { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Ministry> Ministries { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<MentorMentee> MentorsToMentees { get; set; }
        public DbSet<MentorMentor> MentorsToMentors { get; set; }
        public DbSet<Phone> PhoneNumbers { get; set; }
        public DbSet<PersonPhone> PersonToPhone { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PersonAddress> PersonToAddress { get; set; }
        public DbSet<CalendarEvent> Events { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<MentorApplication> MentorApplications { get; set; }
        public DbSet<MentorAvailability> MentorAvailability { get; set; }
        public DbSet<MentorReference> MentorReferences { get; set; }
        public DbSet<Signee> Signees { get; set; }
        public DbSet<EventSignup> EventSignups { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public ApplicationContext()
            : base("DefaultConnection")
        {
        }
        #region Static Lists (This controls the drop-downs)
        public IEnumerable<SelectListItem> YesNoList
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem() 
                    {
                        Value = "0",
                        Text = "No"
                    },
                    new SelectListItem() 
                    {
                        Value = "1",
                        Text = "Yes"
                    }
                };
            }
        }
        public IEnumerable<SelectListItem> BlankSelectDropdownList
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem() 
                    {
                        Value = "0",
                        Text = "Please select ...",
                        Selected = true
                    }
                };
            }
        }
        public IEnumerable<SelectListItem> StatusCodes
        {
            get
            {
                var data = (from r in this.Domains
                            where r.Key == "StatusCode"
                            select r).AsEnumerable()
                            .Select(x => new SelectListItem
                            {
                                Text = x.Value,
                                Value = x.id.ToString()
                            }).ToList();

                data.Insert(0, new SelectListItem { Value = "0", Text = "Please select ...", Selected = true });

                return data;
            }
        }

        public IEnumerable<SelectListItem> Prefixes
        {
            get
            {
                var data = (from r in this.Domains
                            where r.Key == "Prefix"
                            select r).AsEnumerable()
                            .Select(x => new SelectListItem
                            {
                                Text = x.Value,
                                Value = x.id.ToString()
                            }).ToList();
                data.Insert(0, new SelectListItem { Value = "0", Text = "Please select ...", Selected = true });
                return data;
            }
        }

        public IEnumerable<SelectListItem> Suffixes
        {
            get
            {
                var data = (from r in this.Domains
                            where r.Key == "Suffix"
                            select r).AsEnumerable()
                            .Select(x => new SelectListItem
                            {
                                Text = x.Value,
                                Value = x.id.ToString()
                            }).ToList();
                data.Insert(0, new SelectListItem { Value = "0", Text = "Please select ...", Selected = true });
                return data;
            }
        }

        public IEnumerable<SelectListItem> Genders
        {
            get
            {
                var data = (from r in this.Domains
                            where r.Key == "Gender"
                            select r).AsEnumerable()
                            .Select(x => new SelectListItem
                            {
                                Text = x.Value,
                                Value = x.id.ToString()
                            }).ToList();

                data.Insert(0, new SelectListItem { Value = "0", Text = "Please select ...", Selected = true });
                return data;
            }
        }

        public IEnumerable<SelectListItem> Races
        {
            get
            {
                var data = (from r in this.Domains
                            where r.Key == "Race"
                            select r).AsEnumerable()
                            .Select(x => new SelectListItem
                            {
                                Text = x.Value,
                                Value = x.id.ToString()
                            }).ToList();
                data.Insert(0, new SelectListItem { Value = "0", Text = "Please select ...", Selected = true });
                return data;
            }
        }

        public IEnumerable<SelectListItem> MinistriesList
        {
            get
            {
                var data = (from r in this.Ministries
                            select r).AsEnumerable()
                            .Select(x => new SelectListItem
                            {
                                Text = x.MinistryName,
                                Value = x.id.ToString()
                            }).ToList();

                data.Insert(0, new SelectListItem { Value = "0", Text = "Please select ...", Selected = true });
                return data;
            }
        }

        public IEnumerable<SelectListItem> StateList
        {
            get
            {
                var data = (from s in this.States
                            select s).AsEnumerable()
                            .Select(x => new SelectListItem
                            {
                                Text = x.Name,
                                Value = x.StateCode
                            }).ToList();
                data.Insert(0, new SelectListItem { Value = "0", Text = "Please select ...", Selected = true });
                return data;
            }
        }

        public IEnumerable<SelectListItem> CityList
        {
            get
            {
                return (from r in this.Cities select r)
                        .AsEnumerable()
                        .Select(x => new SelectListItem { Text = x.Name, Value = x.id.ToString() });
            }
        }

        public SelectListItem[] GetUserRoles()
        {
            var data = (from r in this.UserRoles
                        select r).AsEnumerable()
                        .Select(x => new SelectListItem
                        {
                            Text = x.Name,
                            Value = x.id.ToString()
                        }).ToArray();
            return data;
        }

        public SelectListItem[] GetUsersDropDownList()
        {
            var data = (from r in this.UserProfiles
                        select r).AsEnumerable()
                        .Select(x => new SelectListItem
                        {
                            Text = x.Username,
                            Value = x.id.ToString()
                        }).ToArray();
            return data;
        }

        public SelectListItem[] GetUsersDropDownList(int UserId)
        {
            var data = (from r in this.UserProfiles
                        where r.id != UserId
                        select r).AsEnumerable()
                        .Select(x => new SelectListItem
                        {
                            Text = x.Username,
                            Value = x.id.ToString()
                        }).ToArray();
            return data;
        }

        public IEnumerable<SelectListItem> ContactTypes
        {
            get
            {
                var data = (from r in this.Domains
                            where r.Key == "ContactType"
                            select r).AsEnumerable()
                            .Select(x => new SelectListItem
                            {
                                Text = x.Value,
                                Value = x.id.ToString()
                            }).ToList();
                data.Insert(0, new SelectListItem { Value = "0", Text = "Please select ...", Selected = true });
                return data;
            }
        }

        public IEnumerable<SelectListItem> EventTypes
        {
            get
            {
                var data = (from r in this.Domains
                            where r.Key == "EventType"
                            select r).AsEnumerable()
                            .Select(x => new SelectListItem
                            {
                                Text = x.Value,
                                Value = x.id.ToString()
                            }).ToList();
                data.Insert(0, new SelectListItem { Value = "0", Text = "Please select ...", Selected = true });
                return data;
            }
        }


        public IEnumerable<SelectListItem> ResourceTypes
        {
            get
            {
                var data = (from r in this.Domains
                            where r.Key == "ResourceType"
                            select r).AsEnumerable()
                            .Select(x => new SelectListItem
                            {
                                Text = x.Value,
                                Value = x.id.ToString()
                            }).ToList();
                data.Insert(0, new SelectListItem { Value = "0", Text = "Please select ...", Selected = true });
                return data;
            }
        }
        #endregion
    }
}