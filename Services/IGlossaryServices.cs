using IBISEvaluation.Models;
using IBISEvaluation.Models.Glossary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBISEvaluation.Services
{
    public interface IGlossaryServices
    {
        //int Add(AddRequest model, string connString);

        List<Entity> GetGlossary(string connString);
    }
}
