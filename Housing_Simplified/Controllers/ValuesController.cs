using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using System.Collections;

namespace Housing_Simplified.Controllers
{
    public class ValuesController : ApiController
    {
        Housing_SimplifiedEntities dbcontext = new Housing_SimplifiedEntities();
        

        Plot plotDetails = new Plot();
        // GET api/values
        public List<Plot> Get()
        {
            var plotList = dbcontext.Plots.ToList();
            return plotList;
        }

        // GET api/values/5
        public Plot Get(int id)
        {
            var plotList = dbcontext.Plots.Where(t=>t.plot_id==id).FirstOrDefault();
            return plotList;
        }

        // POST api/values
        public void Post(Plot plotData)
        {
            Plot data = new Plot();
            data.Name = plotData.Name;
            data.Size = plotData.Size;
            data.Price = plotData.Price;
            data.Note = plotData.Note;
            data.IsSold = plotData.IsSold;
            data.Owner_Name = plotData.Owner_Name;
            data.Owner_Phone = plotData.Owner_Phone;
            dbcontext.Plots.Add(data);
            dbcontext.SaveChanges();
        }

        // PUT api/values/5
        public void Put(Plot plotData)
        {
            var plotDetails = dbcontext.Plots.Where(t => t.plot_id == plotData.plot_id).FirstOrDefault();
            plotDetails.Name = plotData.Name;
            plotDetails.Size = plotData.Size;
            plotDetails.Price = plotData.Price;
            plotDetails.Note = plotData.Note;
            plotDetails.IsSold = plotData.IsSold;
            
            plotDetails.Owner_Phone = plotData.Owner_Phone;
            dbcontext.SaveChanges();

        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            var plotDetails = dbcontext.Plots.Where(t => t.plot_id == id).FirstOrDefault();
            dbcontext.Plots.Remove(plotDetails);
            dbcontext.SaveChanges();
        }
    }
}
