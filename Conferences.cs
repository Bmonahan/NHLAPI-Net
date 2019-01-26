using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;

using Newtonsoft.Json;
namespace NhlAPITest{
  public class confMessage{
        public string copyright {get;set;}
        public List<conf> conferences {get;set;}
    }

    public class conf{
        public int id {get;set;}
        public string name {get;set;}
        public string link {get;set;}
        public string abbreviation {get;set;}
        public string shortName {get;set;}
        public Boolean active {get;set;}
    }
}