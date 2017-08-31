using System;

namespace CrudDemo.Util
{
	public class StringUtil
	{

		public static bool isNotBlank(string str)
		{
			return ! isBlank( str );
		}
		public static bool isBlank(string str)
		{
			return str==null || str.Length==0;
		}

		public static string AddSqlWhere (ref string strSql,  string fieldName, string op, string fieldValue )
		{
			if( fieldName=="" || fieldValue=="" ) return strSql;
			fieldValue = fieldValue.Trim().Replace("'","");
			op = op.Trim().ToLower();

			if( op=="" || op==null ) op="=";
			if( op=="like" && (fieldValue.IndexOf("%")<0 && fieldValue.IndexOf("_")<0 ) )
				fieldValue = "%" + fieldValue + "%";

			string where = fieldName + " " + op + " '"  + fieldValue  + "'" ;

			return AddSqlWhere(ref strSql, where );
		}
		public static string AddSqlWhere (ref string strSql,  string filter )
		{
			if( filter==null || filter.Trim() == "" ) return strSql;
			
			if( strSql.Trim().ToLower().EndsWith("where") ) return strSql = strSql +  filter;
			if( strSql.Trim().ToLower().EndsWith("and") ) return strSql = strSql +  filter;

			//�����и�bug��������Ӳ�ѯ��where��������ѯû��where�������ǲ��Եģ�����Ҫ������ѯ����и�where 1=1
			if( strSql.Trim().ToLower().IndexOf("where") >= 0 ) return strSql = strSql +  " and " + filter;
			return strSql = strSql +  " where " + filter;
		}

		public static string MakeUpdateSql( string [] fields, string []values, string table, string where )
		{
			string strUpdate = "update ["+ table + "] set ";
			for( int i=0; i<fields.Length; i++ )
			{
				string key = fields[i];
				string val = values[ i ];
				if( val == null ) val = ""; //Ϊ���ݴ��ԣ���û�еĲ�����������
				val = val.Replace("'", ""); //Ϊ�˱���sqlע�����⣬��������ȫ��ȥ��
				
				strUpdate += key + "='" + val + "',";
			}
			strUpdate = strUpdate.TrimEnd(',') + " where " + where; //�ĳ��Ա�����Ϊ׼ 2009-8-29

			return strUpdate;

		}

		public static string MakeWhereByComma (string field, string val )
		{
			if( val == ""|| val==null ) return "";
			string [] words = val.Split(",".ToCharArray()); //�����Ŷ�ѡ�Ĺ���
			string sf = "";
			for(int i=0; i<words.Length;i++)
			{
				string w = words[i].Trim();
				if( w=="" ) continue;
				if( sf != "" ) sf += " or ";
				sf += field + " = '" + w +"' ";
			}
			if( sf == "" ) return "";
			return "(" + sf + ")";
		}
		public static string MakeWhereLikeByComma (string field, string val )
		{
			if( val == ""|| val==null ) return "";
			string [] words = val.Split(",".ToCharArray()); //�����Ŷ�ѡ�Ĺ���
			string sf = "";
			for(int i=0; i<words.Length;i++)
			{
				string w = words[i].Trim();
				if( w=="" ) continue;
				if( sf != "" ) sf += " or ";
				sf += field + " like '%" + w +"%' ";
			}
			if( sf == "" ) return "";
			return "(" + sf + ")";
		}


		public static string MakeInsertSql(  string [] fields, string []values, string table )
		{
			string strInsertFld = "";
			string strInsertVal = "";
			for( int i=0; i<fields.Length; i++ )
			{
				string key = fields[i];
				string val = values[ i ];
				if( val == null ) val = ""; //Ϊ���ݴ��ԣ���û�еĲ�����������
				val = val.Replace("'", ""); //Ϊ�˱���sqlע�����⣬��������ȫ��ȥ��
				
				strInsertFld += key + ",";
				strInsertVal += "'" + val + "',";
			}
			string strInsert = "insert into "+ table + "( " + strInsertFld.TrimEnd(',') + " ) values (" + strInsertVal.TrimEnd(',' ) + ")";

			return strInsert;
		}


	}
}
