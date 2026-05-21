using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tubes.Core
{
    public class ManajemenBarang
    {
        [JsonIgnore]
        private static string _filepath = Path.Combine(
                                    AppDomain.CurrentDomain.BaseDirectory,
                                    @"..\..\..\..\dataBarang.json");

        public static BindingList<Barang> daftarBarang { get; set; }

        public static void LoadDataBarang()
        {
            string jsonString = File.ReadAllText(_filepath);

            if (string.IsNullOrEmpty(jsonString))
            {
                daftarBarang = new BindingList<Barang>();
            }
            else
            {
                DataBarang jsonData = JsonSerializer.Deserialize<DataBarang>(jsonString);
                daftarBarang = new BindingList<Barang>(jsonData?.barang ?? new List<Barang>());
            }
        }

        public static void SaveDataBarang()
        {
            var jsonData = new DataBarang { barang = daftarBarang.ToList() };
            string jsonString = JsonSerializer.Serialize(jsonData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filepath, jsonString);
        }
        
        public static OperationResult IdValidation(int id)
        {
            if (id <= 0)
            {
                return OperationResult.Fail("ID harus lebih besar dari 0");
            }

            foreach (var barang in daftarBarang)
            {
                if (barang.id == id)
                {
                    return OperationResult.Fail("ID sudah digunakan");
                }
            }

            return OperationResult.Success();

        }

        public static OperationResult TambahBarang(Barang barang)
        {
            if(barang == null) return OperationResult.Fail("Barang tidak boleh null");

            daftarBarang.Add(barang);
            return OperationResult.Success();
        }

        private static int GetBarang(int id)
        {
            int ix = -1;
            for(int i = 0; i < daftarBarang.Count; i++)
            {
                if(daftarBarang[i].id == id)
                {
                    ix = i;
                    break;
                }
            }
            return ix;
        }

        public static OperationResult EditBarang(int id, Barang updatedBarang)
        {
            int index = GetBarang(id);
            if(index == -1) return OperationResult.Fail("Barang tidak ditemukan");
            daftarBarang[index] = updatedBarang;
            return OperationResult.Success();
        }

        public static OperationResult HapusBarang(int id)
        {
            int index = GetBarang(id);
            if(index == -1) return OperationResult.Fail("Barang tidak ditemukan");
            daftarBarang.RemoveAt(index);
            return OperationResult.Success();
        }

        class DataBarang
        {
            public List<Barang> barang { get; set; }
        }
    }
}
