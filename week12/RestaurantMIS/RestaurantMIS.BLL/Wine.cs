using System;
using System.Data;
using System.Collections.Generic;

using RestaurantMIS.Model;
namespace RestaurantMIS.BLL
{
	/// <summary>
	/// ҵ���߼���Wine ��ժҪ˵����
	/// </summary>
	public class Wine
	{
		private readonly RestaurantMIS.DAL.Wine dal=new RestaurantMIS.DAL.Wine();
		public Wine()
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
		public void Add(RestaurantMIS.Model.Wine model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(RestaurantMIS.Model.Wine model)
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
		public RestaurantMIS.Model.Wine GetModel(int ID)
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
		public List<RestaurantMIS.Model.Wine> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<RestaurantMIS.Model.Wine> DataTableToList(DataTable dt)
		{
			List<RestaurantMIS.Model.Wine> modelList = new List<RestaurantMIS.Model.Wine>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				RestaurantMIS.Model.Wine model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new RestaurantMIS.Model.Wine();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					model.Name=dt.Rows[n]["Name"].ToString();
					model.Type=dt.Rows[n]["Type"].ToString();
					model.Unit=dt.Rows[n]["Unit"].ToString();
					if(dt.Rows[n]["YesterdayStorkNum"].ToString()!="")
					{
						model.YesterdayStorkNum=int.Parse(dt.Rows[n]["YesterdayStorkNum"].ToString());
					}
					if(dt.Rows[n]["TodayInNum"].ToString()!="")
					{
						model.TodayInNum=int.Parse(dt.Rows[n]["TodayInNum"].ToString());
					}
					if(dt.Rows[n]["TodayOutNum"].ToString()!="")
					{
						model.TodayOutNum=int.Parse(dt.Rows[n]["TodayOutNum"].ToString());
					}
					if(dt.Rows[n]["TodayStorkNum"].ToString()!="")
					{
						model.TodayStorkNum=int.Parse(dt.Rows[n]["TodayStorkNum"].ToString());
					}
					if(dt.Rows[n]["Price"].ToString()!="")
					{
						model.Price=decimal.Parse(dt.Rows[n]["Price"].ToString());
					}
					if(dt.Rows[n]["IncomeSum"].ToString()!="")
					{
						model.IncomeSum=decimal.Parse(dt.Rows[n]["IncomeSum"].ToString());
					}
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
            return dal.GetDistinctCol(colName);
        }

        public string GetYesterdayStork(DateTime date, string name)
        {
            return dal.GetYesterdayStork(date,name);
        }

		#endregion  ��Ա����
	}
}

