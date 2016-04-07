﻿using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.ShopCaTables
{
    /*
     * An abstract class that inherient ExportTable class and override getSKU for all ShopCa subclasses
     */
    public abstract class ShopCaExportTable : ExportTable
    {
        /* a method that get all the sku that is active */
        protected override string[] getSku()
        {
            // local field for storing data
            List<string> skuList = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True' AND SKU_SHOP_CA != '' ORDER BY SKU_Ashlin", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                skuList.Add(reader.GetString(0));
            connection.Close();

            return skuList.ToArray();
        }

        /* define other getData() method */
        protected abstract ArrayList getData(string sku);
    }
}
