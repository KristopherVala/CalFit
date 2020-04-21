using System;
using System.Collections.Generic;
using System.Text;

namespace MobileFitnessCalorieTracker.Models
{
    class MealDeSerializer
    {
    }
        public class Rootobject
        {
            public double total_hits { get; set; }
            public float max_score { get; set; }
            public Hit[] hits { get; set; }
        }

        public class Hit
        {
            public string _index { get; set; }
            public string _type { get; set; }
            public string _id { get; set; }
            public float _score { get; set; }
            public Fields fields { get; set; }
        }

        public class Fields
        {
            public object old_api_id { get; set; }
            public string item_id { get; set; }
            public string item_name { get; set; }
            public string brand_id { get; set; }
            public string brand_name { get; set; }
            public object item_description { get; set; }
            public DateTime updated_at { get; set; }
            public object nf_ingredient_statement { get; set; }
            public object nf_water_grams { get; set; }
            public double nf_calories { get; set; }
            public double nf_calories_from_fat { get; set; }
            public double nf_total_fat { get; set; }
            public double nf_saturated_fat { get; set; }
            public double nf_trans_fatty_acid { get; set; }
            public object nf_polyunsaturated_fat { get; set; }
            public object nf_monounsaturated_fat { get; set; }
            public double nf_cholesterol { get; set; }
            public double nf_sodium { get; set; }
            public double nf_total_carbohydrate { get; set; }
            public double nf_dietary_fiber { get; set; }
            public double nf_sugars { get; set; }
            public double nf_protein { get; set; }
            public float nf_vitamin_a_dv { get; set; }
            public double nf_vitamin_c_dv { get; set; }
            public double nf_calcium_dv { get; set; }
            public double nf_iron_dv { get; set; }
            public object nf_refuse_pct { get; set; }
            public double nf_servings_per_container { get; set; }
            public double nf_serving_size_qty { get; set; }
            public string nf_serving_size_unit { get; set; }
            public double nf_serving_weight_grams { get; set; }
            public object allergen_contains_milk { get; set; }
            public object allergen_contains_eggs { get; set; }
            public object allergen_contains_fish { get; set; }
            public object allergen_contains_shellfish { get; set; }
            public object allergen_contains_tree_nuts { get; set; }
            public object allergen_contains_peanuts { get; set; }
            public object allergen_contains_wheat { get; set; }
            public object allergen_contains_soybeans { get; set; }
            public object allergen_contains_gluten { get; set; }
        }


    





}
