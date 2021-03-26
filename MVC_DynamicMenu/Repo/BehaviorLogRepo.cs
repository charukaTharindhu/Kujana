using Microsoft.EntityFrameworkCore;
using MVC_DynamicMenu.Data;
using MVC_DynamicMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Repo
{
	public class BehaviorLogRepo
	{
		private readonly DynamicMenuDBContext _context = null;

		public BehaviorLogRepo(DynamicMenuDBContext context)
		{
			_context = context;
		}


		public Client getUserById(int id)
		{
			var obj = _context.Client
			.FromSqlRaw("SELECT * FROM dbo.Client WHERE ClientID=" + id)
			.ToList();

			return obj[0];
		}
		public void AddNewBehaviorLog(BehaviorLog Blog)
		{
			var NewLog = new BehaviorLog
			{
				Reference = Blog.Reference,
				Client = Blog.Client,
				Unit = Blog.Unit,
				Entry_Date = Blog.Entry_Date,
				Last_Updated = Blog.Last_Updated
			};
			_context.BehaviorLog.Add(Blog);
			_context.SaveChanges();

		}
	}
}
