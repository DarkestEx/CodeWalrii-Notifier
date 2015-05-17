﻿using System;
using Gtk;
using System.Collections.Generic;

namespace CodeWalriiNotify
{
	public partial class MainWindow: Window
	{
		public MainWindow()
			: base(WindowType.Toplevel)
		{
			Build();
		}

		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
			a.RetVal = true;
		}

		protected void OnRefreshButtonClicked(object sender, EventArgs e)
		{
			RefreshPosts();
		}

		protected void RefreshPosts()
		{
			var fdr = new FeedRetriever("http://api.muessigb.net/walrus_notify.php", "http://codewalr.us/index.php?action=.xml");
			String js = fdr.RetrieveData("");
			PostMeta.FromJSON(js);
			//MessageBox.Show(lal.ToString(), MessageType.Info);

			postwidget1.Title = "Lol";

		}
	}
}