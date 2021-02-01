using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LandmarkAPI.Data;
using LandmarksAPI.Models;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Net.Http;
using Nancy.Json;

namespace LandmarkAPI.Controllers
{
    public class LocationsController : Controller
    {
        private readonly LandmarkDbContext _context;

        public LocationsController(LandmarkDbContext context)
        {
            _context = context;
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Locations.ToListAsync());
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations
                .FirstOrDefaultAsync(m => m.LocationKey == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Locations/Create
        public IActionResult Search()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search([Bind("LocationKey,Id,Lat,Lng")] Location location)
        {
            

            Regex floating = new Regex(@"^[0-9]*(?:\.[0-9]+)?$");
            //string Lat = "40.8004";
            //string Lng = "-72.0018";

            //string Latitude = location.Lat.ToString();
            //double Latitude = Convert.ToDouble(location.Lat.ToString());
            //double Longitude = Convert.ToDouble(location.Lng.ToString());

            if (location.Lat == null|| location.Lng ==null)
            {
                return NotFound();
            }

            var stopWach = Stopwatch.StartNew();
                    using (var client = new HttpClient())
                    {
                        ///40.7243,-74.0018
                        client.BaseAddress = new Uri("https://localhost:44363/");
                        var result = await client.GetAsync("https://api.foursquare.com/v2/venues/explore?client_id=VDAMWS0K5GTMS1GNSH3ALHJVM5LMBL2OHYFSIML53MTJFBZD&client_secret=H44SNTWPILK2LFVTH4CTP0X5H4IP2VAHTKUL2YI0VKZWH4JW&v=20180323&limit=1&ll=" + location.Lat + "," + location.Lng + "&query=landmarks");
                        string resultContentString = await result.Content.ReadAsStringAsync();

                        dynamic json = new JavaScriptSerializer().Deserialize<dynamic>(resultContentString);


                        var landmarkDetails = json.response["groups"];
                        //get the venues
                        var _landMarkVenue = new Venue
                        {
                            Id = landmarkDetails[0].items[0].venue.id,
                            Name = landmarkDetails[0].items[0].venue.name,
                        };
                        _context.Add(_landMarkVenue);
                        // venueTable.Add(_landMarkVenue);

                        //get location
                        var _landmarkLocation = new Location
                        {
                          
                            Address = landmarkDetails[0].items[0].venue.location.address,
                            Lat =Convert.ToString(landmarkDetails[0].items[0].venue.location.lat),
                            Lng = Convert.ToString(landmarkDetails[0].items[0].venue.location.lng),
                            City = landmarkDetails[0].items[0].venue.location.city,
                            Country = landmarkDetails[0].items[0].venue.location.country,
                        };
                        // location = _landmarkLocation;
                        location.Lat = _landmarkLocation.Lat;
                        location.Lng = _landmarkLocation.Lng;

                        _context.Add(_landmarkLocation);

                        //get categories
                        var _landmarkCategory = new Category
                        {
                            Id = landmarkDetails[0].items[0].venue.categories[0].id,
                            Name = landmarkDetails[0].items[0].venue.categories[0].name,
                        };
                        // categoriesTable.Add(_landmarkCategory);
                        _context.Add(_landmarkCategory);
                        //get icon/image
                        var _landmarkImage = new Icon
                        {
                            Prefix = landmarkDetails[0].items[0].venue.categories[0].icon.prefix,
                            Suffix = landmarkDetails[0].items[0].venue.categories[0].icon.suffix,
                            //ImageBytes =landmarkDetails[0].items[0].venue.categories[0].icon.images
                        };
                        _context.Add(_landmarkImage);
                        // iconTable.Add(_landmarkImage);
                       // if (_context.Icons.Any(image => image.Prefix == _landmarkImage.Prefix))
                         //  return View("image already exists");
                        await _context.SaveChangesAsync();

                    }
                    stopWach.Stop();

                    if (ModelState.IsValid)
                    {
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    return View(location);
           
        }
      
        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationKey,Id,Address,Lat,Lng,Distance,PostalCode,Cc,City,State,Country")] Location location)
        {
            if (id != location.LocationKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.LocationKey))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations
                .FirstOrDefaultAsync(m => m.LocationKey == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.LocationKey == id);
        }
    }
}
