using System;
namespace RestaurantMIS.Model
{
	/// <summary>
	/// ʵ����PaySum ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class PaySum
	{
		public PaySum()
		{}
		#region Model

		private string _saler;
		private decimal _yesterdaysum;
		private decimal _todaymoney;
		private decimal _todaysum;
		private DateTime _logdate;

		/// <summary>
		/// 
		/// </summary>
		public string ������
		{
			set{ _saler=value;}
			get{return _saler;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ��������
		{
			set{ _yesterdaysum=value;}
			get{return _yesterdaysum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ���ս��
		{
			set{ _todaymoney=value;}
			get{return _todaymoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal �ۼƽ��
		{
			set{ _todaysum=value;}
			get{return _todaysum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ����
		{
			set{ _logdate=value;}
			get{return _logdate;}
		}

        public string ��ע { get; set; }
		#endregion Model

	}
}

