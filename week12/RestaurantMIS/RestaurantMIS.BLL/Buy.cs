using System;
using System.Data;
using System.Collections.Generic;

using RestaurantMIS.Model;
namespace RestaurantMIS.BLL
{
	/// <summary>
	/// ҵ���߼���Buy ��ժҪ˵����
	/// </summary>
	public class Buy
	{
		private readonly RestaurantMIS.DAL.Buy dal=new RestaurantMIS.DAL.Buy();
		public Buy()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(RestaurantMIS.Model.Buy model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(RestaurantMIS.Model.Buy model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ID)
		{
			
			dal.Delete(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public RestaurantMIS.Model.Buy GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}


		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<RestaurantMIS.Model.Buy> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<RestaurantMIS.Model.Buy> DataTableToList(DataTable dt)
		{
			List<RestaurantMIS.Model.Buy> modelList = new List<RestaurantMIS.Model.Buy>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				RestaurantMIS.Model.Buy model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new RestaurantMIS.Model.Buy();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					model.Saler=dt.Rows[n]["Saler"].ToString();
					model.Product=dt.Rows[n]["Product"].ToString();
					model.Type=dt.Rows[n]["Type"].ToString();
					if(dt.Rows[n]["Price"].ToString()!="")
					{
						model.Price=decimal.Parse(dt.Rows[n]["Price"].ToString());
					}
					model.Unit=dt.Rows[n]["Unit"].ToString();
					if(dt.Rows[n]["Num"].ToString()!="")
					{
						model.Num=decimal.Parse(dt.Rows[n]["Num"].ToString());
					}
					if(dt.Rows[n]["Money"].ToString()!="")
					{
						model.Money=decimal.Parse(dt.Rows[n]["Money"].ToString());
					}
					model.Category=dt.Rows[n]["Category"].ToString();
					if(dt.Rows[n]["LogDate"].ToString()!="")
					{
						model.LogDate=DateTime.Parse(dt.Rows[n]["LogDate"].ToString());
					}
					model.Memo=dt.Rows[n]["Memo"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

        public List<string> GetDistinctCol(string colName)
        {
            return dal.GetDistinctCol(colName,null);
        }

        public List<string> GetDistinctCol(string colName, string category)
        {
            return dal.GetDistinctCol(colName, category);
        }

        public void Pay(string saler, string date)
        {
            dal.Pay(saler, date);
        }
		#endregion  ��Ա����
	}
}

