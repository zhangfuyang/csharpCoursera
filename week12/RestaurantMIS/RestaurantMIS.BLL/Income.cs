using System;
using System.Data;
using System.Collections.Generic;

using RestaurantMIS.Model;
namespace RestaurantMIS.BLL
{
	/// <summary>
	/// ҵ���߼���Income ��ժҪ˵����
	/// </summary>
	public class Income
	{
		private readonly RestaurantMIS.DAL.Income dal=new RestaurantMIS.DAL.Income();
		public Income()
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
		public void Add(RestaurantMIS.Model.Income model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(RestaurantMIS.Model.Income model)
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
		public RestaurantMIS.Model.Income GetModel(int ID)
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
		public List<RestaurantMIS.Model.Income> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<RestaurantMIS.Model.Income> DataTableToList(DataTable dt)
		{
			List<RestaurantMIS.Model.Income> modelList = new List<RestaurantMIS.Model.Income>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				RestaurantMIS.Model.Income model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new RestaurantMIS.Model.Income();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["IncomeSum"].ToString()!="")
					{
						model.IncomeSum=decimal.Parse(dt.Rows[n]["IncomeSum"].ToString());
					}
					if(dt.Rows[n]["IncomeMoneySum"].ToString()!="")
					{
						model.IncomeMoneySum=decimal.Parse(dt.Rows[n]["IncomeMoneySum"].ToString());
					}
					if(dt.Rows[n]["DishMoney"].ToString()!="")
					{
						model.DishMoney=decimal.Parse(dt.Rows[n]["DishMoney"].ToString());
					}
					if(dt.Rows[n]["WineMoney"].ToString()!="")
					{
						model.WineMoney=decimal.Parse(dt.Rows[n]["WineMoney"].ToString());
					}
					if(dt.Rows[n]["OtherMoney"].ToString()!="")
					{
						model.OtherMoney=decimal.Parse(dt.Rows[n]["OtherMoney"].ToString());
					}
					if(dt.Rows[n]["IncomeLendSum"].ToString()!="")
					{
						model.IncomeLendSum=decimal.Parse(dt.Rows[n]["IncomeLendSum"].ToString());
					}
					if(dt.Rows[n]["ReturnSum"].ToString()!="")
					{
						model.ReturnSum=decimal.Parse(dt.Rows[n]["ReturnSum"].ToString());
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

		#endregion  ��Ա����
	}
}

