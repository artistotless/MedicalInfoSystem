using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTrader
{
   public class BuyerLicense
    {


        public class Col19
        {
            public string label { get; set; }
            public string title { get; set; }
        }

        public class Col9
        {
            public string label { get; set; }
        }

        public class Col10
        {
            public string label { get; set; }
        }

        public class Col2
        {
            public string label { get; set; }
        }

        public class Col4
        {
            public string title { get; set; }
            public string label { get; set; }
        }

        public class Col18
        {
            public string label { get; set; }
        }

        public class Col3
        {
            public string title { get; set; }
            public string label { get; set; }
        }

        public class Col1
        {
            public string label { get; set; }
        }

        public class Col7
        {
            public string label { get; set; }
        }

        public class Col8
        {
            public string label { get; set; }
        }

        public class Col11
        {
            public string label { get; set; }
        }

        public class Object
        {
            public string id_voc_revision_object_type { get; set; }
            public string id_voc_district { get; set; }
            public string region { get; set; }
            public string id_voc_revision_activity_items { get; set; }
            public string id_voc_region { get; set; }
            public string okato { get; set; }
            public object ext_db { get; set; }
            public string id_department { get; set; }
            public string kladr { get; set; }
            public object ext_type_id { get; set; }
            public string fake { get; set; }
            public string id_voc_producer { get; set; }
            public object ext_city_id { get; set; }
            public string is_active_b2b { get; set; }
            public string address_fact_street { get; set; }
            public string address_fact_zip { get; set; }
            public object ext_region_id { get; set; }
            public string id_create_user { get; set; }
            public string is_not_code_fias { get; set; }
            public string from_b2b { get; set; }
            public string id_voc_city { get; set; }
            public string id { get; set; }
            public object label_short { get; set; }
            public string is_foreign { get; set; }
            public object building_num { get; set; }
            public object id_revision { get; set; }
            public string oktmo { get; set; }
            public object ext_org { get; set; }
            public string code_fias { get; set; }
            public string is_actual { get; set; }
            public string dt_created { get; set; }
            public string label { get; set; }
            public string id_user_edited { get; set; }
            public string address_fact { get; set; }
            public object ext_id { get; set; }
            public string id_voc_licenser { get; set; }
            public object house_num { get; set; }
            public string is_save_region { get; set; }
            public string activity { get; set; }
            public string district_label { get; set; }
            public string is_med_business_check { get; set; }
            public string city { get; set; }
            public object appartment_num { get; set; }
            public string dt_edited { get; set; }
            public object street { get; set; }
            public string id_voc_settlements { get; set; }
            public string id_organization { get; set; }
            public object ids_voc_revision_activities { get; set; }
            public string id_type_org { get; set; }
            public string id_licenses_apps_object { get; set; }
            public object label_firm { get; set; }
        }

        public class Col16
        {
            public string label { get; set; }
        }

        public class Col17
        {
            public string title { get; set; }
            public string label { get; set; }
        }

        public class Col14
        {
            public string label { get; set; }
        }

        public class Col12
        {
            public string label { get; set; }
        }

        public class Col15
        {
            public string label { get; set; }
        }

        public class Col6
        {
            public string label { get; set; }
        }

        public class Col5
        {
            public string label { get; set; }
        }

        public class Col13
        {
            public string label { get; set; }
        }

        public class Datum
        {
            public Col19 col19 { get; set; }
            public Col9 col9 { get; set; }
            public Col10 col10 { get; set; }
            public Col2 col2 { get; set; }
            public Col4 col4 { get; set; }
            public Col18 col18 { get; set; }
            public Col3 col3 { get; set; }
            public Col1 col1 { get; set; }
            public Col7 col7 { get; set; }
            public Col8 col8 { get; set; }
            public string DT_RowId { get; set; }
            public Col11 col11 { get; set; }
            public List<Object> objects { get; set; }
            public Col16 col16 { get; set; }
            public Col17 col17 { get; set; }
            public Col14 col14 { get; set; }
            public Col12 col12 { get; set; }
            public Col15 col15 { get; set; }
            public Col6 col6 { get; set; }
            public Col5 col5 { get; set; }
            public Col13 col13 { get; set; }
        }

      
            public int recordsFiltered { get; set; }
            public int recordsTotal { get; set; }
            public string draw { get; set; }
            public List<Datum> data { get; set; }
        



        //string licensor;
        //string regNumber;
        //string companyName;
        //string startDate;
        //string endDate;
        //bool isActive;
        //string pdfUrl;
    }
}
