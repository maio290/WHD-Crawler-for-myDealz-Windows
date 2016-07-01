// File created on 31.05.2016 at 15:36
// All rights reserved, do not redistribute.
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WHD_Crawler
{
	/// <summary>
	/// Alles in einem, C# ist nicht ganz meine Domäne, sorry.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		// Crawler functions
		string get_html_from_url(string URL)
		{
			using(WebClient cl = new WebClient())
			{
				return cl.DownloadString(URL);
			}
		}

		string get_html_from_url_utf8(string URL)
		{
			// used to access idealo, encodings suck in C#
			using(WebClient cl = new WebClient())
			{
				cl.Encoding = System.Text.Encoding.UTF8;
				return cl.DownloadString(URL);
			}
		}
		
		List<string> get_idealo(string productname)
		{
			productname = productname.Trim();
			productname = productname.Replace(" ","+");
			string idealourl = "http://www.idealo.de/preisvergleich/MainSearchProductCategory.html?q="+productname;
			string idealohtml = get_html_from_url_utf8(idealourl);

			List<string> prices = extract_all_html(idealohtml,"<span class=\"price bold nobr block fs-18\">","</span>");
			List<string> names = extract_idealo_names(idealohtml);
			List<string> idealo = new List<string>();
			
			
			for(int i = 0; i<prices.Count; i++)
			{
				string price = prices[i];		
				
				int check = price.IndexOf("&");
				if(check != -1)
				{price = price.Substring(0,check);}
				
				price = price.Trim();
				price = price.Replace("€","");
								
				string name;
				
				try
				{name = names[i];}
					catch(ArgumentOutOfRangeException)
					{continue;}

				//TODO: Seems like there is a weird bug with Windows10 and UTF-8.
				//The name string may contain a SOFT HYPHEN (C2AD, 0xC2 0xAD)
				name = name.Trim();
				
				
				string ret = "Idealo ("+name+"): "+price;
				idealo.Add(ret);
			}
			
			return idealo;
		}
				
		// extract functions for idealo 
		
		List<string> extract_idealo_names(string HTML)
		{
				
				// because idealo is a bit weird.
				List<string> html_list = new List<string>();
				int offset = 0;
				while(offset != -1)
				{
					int start;
					int real_start;
					int end;	
					
					string html_pattern_start = "<a class=\"offer-title link-2 webtrekk\"";
					string html_pattern_real_start = ">";
					string html_pattern_end = "<";
					
					try
					{
					start = HTML.IndexOf(html_pattern_start,offset);
					real_start = HTML.IndexOf(html_pattern_real_start,start+1);
					end = HTML.IndexOf(html_pattern_end,real_start);}
						catch(ArgumentOutOfRangeException)
						{return html_list;}

					if(start == -1 || end == -1 || real_start == -1)
					{
						break;
					}
					
					string html_extract = HTML.Substring(real_start+html_pattern_real_start.Length,end-real_start-html_pattern_real_start.Length);
					
					
					
					html_list.Add(html_extract);
					offset = end;
					continue;
				}
				
				return html_list;				
		
		}
		
		List<string> extract_all_html(string HTML,string html_pattern_start, string html_pattern_end)
		{
			/*
			Encoding enc = new UTF8Encoding(true,true); 
			byte[] enc_bytes = enc.GetBytes(html_pattern_end);
			html_pattern_end = enc.GetString(enc_bytes);
			*/
						
				List<string> html_list = new List<string>();
				int offset = 0;
				while(offset != -1)
				{
					int start;
					int end;	
					try
					{
					start = HTML.IndexOf(html_pattern_start,offset);
					end = HTML.IndexOf(html_pattern_end,start);}
						catch(ArgumentOutOfRangeException)
						{return html_list;}

						
					if(start == -1 || end == -1)
					{
						break;
					}
					
					string html_extract = HTML.Substring(start+html_pattern_start.Length,end-start-html_pattern_start.Length);
					html_list.Add(html_extract);
					offset = end;
					continue;
				}
				
				return html_list;
		}
		

		string extract_image(string HTML)
		{
			string html_pattern_start = "<img src=\"";
			string html_pattern_end = "\"";	
			
			
			int start = HTML.IndexOf(html_pattern_start);
			int end = HTML.IndexOf(html_pattern_end,start+html_pattern_start.Length);
			
			string img = HTML.Substring(start+html_pattern_start.Length,end-start-html_pattern_start.Length);
			
			return img;		
		
		}
		
		string extract_name(string HTML)
		{
			string html_pattern_start = "<b id=\"product-title\">";
			string html_pattern_end = "</b>";	
			
			int start = HTML.IndexOf(html_pattern_start);
			int end = HTML.IndexOf(html_pattern_end,start);
			
			if(start == -1 || end == -1)
			{
				throw new ArgumentNullException();
			}
			
			string name = HTML.Substring(start+html_pattern_start.Length,end-start-html_pattern_start.Length);
			
			return name;
		}
		
		string extract_whd_state(string offer)
		{
			string pattern_start = ">";
			string pattern_end = "-";
			
			int start = offer.IndexOf(pattern_start);
			int end = offer.IndexOf(pattern_end,start);
			
			string state = offer.Substring(start+pattern_start.Length,end-start-pattern_start.Length);	
			
			return state.Trim();
		}
		
		string extract_whd_price(string offer)
		{
			
			string pattern_start = "EUR";
			
			int start = offer.IndexOf(pattern_start);
	
			string price = offer.Substring(start+pattern_start.Length);
			
			price = price.Replace(".","");
			
			return price;
		
		}

		
		string extract_price(string HTML)
		{
			int start;
			int end;
			string html_pattern_start = "<b>Preis:</b>";
			string html_pattern_end = "<br />";
			
			try
			{start = HTML.IndexOf(html_pattern_start);
			end = HTML.IndexOf(html_pattern_end,start);}
				catch(ArgumentOutOfRangeException)
				{return "-1";}
			
			if(start == -1 || end == -1)
			{
				//MessageBox.Show("Failed to fetch price :/");
				return "-1";
			}
			
			string price = HTML.Substring(start+html_pattern_start.Length,end-start-html_pattern_start.Length);
			
			price = price.Replace("EUR","");
			price = price.Replace("&nbsp;","");
			price = price.Replace(".","");
			
			return price;
			
			
		}
		
		List<string> extract_ahref(string HTML)
		{
		
				// this function extracts all occurences of a href elements
				// since arrays are not as nice as in PHP, we do use a list here.
				// beause indexing arrays sucks sometimes.
				
				List<string> offer_list = new List<string>();
				
				
				// offset variable is used for breaking the loop
				int offset = 0;
				
				// -1 is error code of String.IndexOf
				while(offset != -1)
				{
					int start;
					int end;
					
					string html_pattern_start = "<a href=\"/gp/aw/ol/";
					string html_pattern_end = "</a>";
					
					// cut the ahref with the current offset 
					
					try
					{
					start = HTML.IndexOf(html_pattern_start,offset);
					end = HTML.IndexOf(html_pattern_end,start);
					}
					catch(ArgumentOutOfRangeException)
					{
						return offer_list;
					}

					
					if(start == -1 || end == -1)
					{
						break;
					}
					
					string ahref = HTML.Substring(start+html_pattern_start.Length,end-start-html_pattern_start.Length);
					
					// check if the ahref is a WHD
					
					string merchant = "&me=A8KICS1PHF7ZO";
					
					if(ahref.IndexOf(merchant) != -1)
					{
						// if, add to List.
						offer_list.Add(ahref);
						offset = end;
						continue;
						
					}
					else
					{
						// if not, go forward brave soilder
						offset = end;
						continue;
					}

				}
				
				return offer_list;
		}
		
		string extract_asin(string URL)
		{
			string[] search_structure = {"/dp/","/gp/product/","/gp/aw/d/","/gp/offer-listing/"};
			
			foreach(string keyword in search_structure)
			{
				if(URL.IndexOf(keyword) != -1)
				{
					
					int start = URL.IndexOf(keyword);
					int end = URL.IndexOf("/",start+keyword.Length);
					
					string ASIN = URL.Substring(start+keyword.Length,10);
					
					return ASIN;
				}
			}
			throw new ArgumentNullException();
			
		}
		

		
		int determine_pages(string HTML)
		{
			int entries_per_page = 10;
			string html_pattern_start = "<a name=\"Used\">";
			string html_pattern_end = "</a>";	
			
			int start = HTML.IndexOf(html_pattern_start);
			int end = HTML.IndexOf(html_pattern_end,start);
			
			if(start == -1 || end == -1)
			{
				throw new ArgumentNullException();
			}
			
			string qty = HTML.Substring(start+html_pattern_start.Length,end-start-html_pattern_start.Length);
			
			string qty_real = qty.Substring(qty.IndexOf("/")+1);
			
			int qty_int = Convert.ToInt32(qty_real);
			
			if(qty_int % 10 != 0)
			{
				return (qty_int/entries_per_page)+1;
			}
			else
			{
				return (qty_int/entries_per_page);
			}
			
		}
		
		
		string prepare_mobile(string ASIN)
		{
			return "http://amazon.de/gp/aw/d/"+ASIN+"/";
		}
		
		string prepare_desktop(string ASIN)
		{
			return "http://amazon.de/dp/"+ASIN+"/?me=A8KICS1PHF7ZO";
		}

		// Event based C# magic
		
		void Update_Progressbar(int value)
		{
			DL_Progress.Value = value;
			DL_Progress.Update();
		}
		
		void Idealo_Clickl(object sender, EventArgs e)
		{
			Heise_Checkbox.Checked = false;
		}
		
		void Heise_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Diese Funktionalität wurde noch nicht implementiert, tut mir Leid.");
			Heise_Checkbox.Checked = false;
			//Idealo_Checkbox.Checked = false;
		}
		
		void crawl(object sender, EventArgs e)
		{
			
			string ASIN;
			string name;
			string price;
			string TAG = "&tag=80098-21";
			
			double discount = 0.00;
			double discount_fraction = 0.00;
			bool discount_active = false;
			
			Update_Progressbar(0);
			Idealo.Text = "";
			string Euro = " EUR";
			
			if(Euro_Checkbox.Checked == true)
			{
			Euro = " €";
			}
			
			
			if(URL_TextBox.TextLength == 0)
			 {
				MessageBox.Show("Bitte einen Link in das Textfeld eintragen!");
				return;
			 }
			
			if(Discount_TB.Text.Length > 0)
			{
				discount_active = true;
				
				Discount_TB.Text = Discount_TB.Text.Replace(",",".");
				
				try
				{
				discount = Convert.ToDouble(Discount_TB.Text);
				
				discount_fraction =  (1-(discount/100));
				}
				catch(FormatException)
				{
					MessageBox.Show("Bitte den Rabatt in der Form 00 bzw. 00.00 eintragen!");
					Discount_TB.Text = "";
					return;
				}
			}
			
			// This is the equivalent of get_data 
			// First of all, we are trying to get the article name and the new price of the article, inherit the code as you like.
			
				try
				{ASIN = extract_asin(URL_TextBox.Text);}
					catch(ArgumentNullException)
					{MessageBox.Show("Fehler beim Extrahieren der ASIN. War der Link ungültig?");
					return;}
				
			string html = get_html_from_url(prepare_mobile(ASIN));
			Update_Progressbar(10);
			
				try
				{name = extract_name(html);}
					catch(ArgumentNullException)
					{MessageBox.Show("Fehler beim Extrahieren des Namens");
					return;}
				
				price = extract_price(html);
				double price_dbl = Convert.ToDouble(price.Replace(",","."));
				if(price_dbl == -1)
				{price = "Kein Neupreis auf Amazon vorhanden!";
				}else{
					price = "Neupreis auf Amazon.de: " + price + Euro;
					}
				
				// Ok, now we are starting to fetch the actual WHD offers
				

				string price_url = prepare_mobile(ASIN).Replace("/d","/ol");
				price_url += "?o=Used&op=1";
						
				string price_html = get_html_from_url(price_url);
					
				int pages = determine_pages(price_html);
				
				Update_Progressbar(30);
				
				List<string> offers = new List<string>();
				List<string> offers_loop;
				
				bool acceptable = false;
				bool good = false;
				bool very_good = false;
				bool as_new = false; 
				
				for(int i = 1; i<= pages; i++)
				{
					if(i == 1)
					{
						// no modification of the url needed
						offers_loop = extract_ahref(price_html);	
					}
					else
					{
						// modify url
						 price_url = prepare_mobile(ASIN).Replace("/d","/ol");
					     price_url += "?o=Used&op="+i;
					     price_html = get_html_from_url(price_url);
					     offers_loop = extract_ahref(price_html);	
					}
					
					if(acceptable == true && good == true && very_good == true && as_new == true)
					{
						// this is very unlikely, but if it happens, why not.
						break;
					}
					
						foreach(string offer in offers_loop)
						{
						
							// offers are ensured WHD, now just check their state and extract the prices properly
							switch(extract_whd_state(offer))
							{
								case "Akzeptabel":
									if(acceptable == false)
									{
										if(discount_active == true)
										{
											
											double tmp_price = Convert.ToDouble(extract_whd_price(offer));
											double final_price = tmp_price * discount_fraction;
											offers.Add("Akzeptabel - " + String.Format("{0:0.00}",tmp_price) + Euro + " * " + String.Format("{0:0.00}",discount_fraction) + " = " + String.Format("{0:0.00}",Math.Round(final_price,2)) + Euro);
											
										}
										else
										{
										offers.Add("Akzeptabel - " + extract_whd_price(offer) + Euro);
										}
										
										acceptable = true;
									}
								break;
									
								case "Gut":
									if(good == false)
									{
										if(discount_active == true)
										{
											double tmp_price = Convert.ToDouble(extract_whd_price(offer));
											double final_price = tmp_price * discount_fraction;	
											offers.Add("Gut - " + String.Format("{0:0.00}",tmp_price) + Euro + " * " + String.Format("{0:0.00}",discount_fraction) + " = " + String.Format("{0:0.00}",Math.Round(final_price,2)) + Euro);
										}
										else
										{
										offers.Add("Gut - " + extract_whd_price(offer) + Euro);
										}
										
										good = true;									
									}
								break;
								
								case "Sehr gut":
									if(very_good == false)
									{
										if(discount_active == true)
										{
											double tmp_price = Convert.ToDouble(extract_whd_price(offer));
											double final_price = tmp_price * discount_fraction;		
											offers.Add("Sehr gut - " + String.Format("{0:0.00}",tmp_price) + Euro + " * " + String.Format("{0:0.00}",discount_fraction) + " = " + String.Format("{0:0.00}",Math.Round(final_price,2)) + Euro);
										}
										else
										{
										offers.Add("Sehr gut - " + extract_whd_price(offer) + Euro);
										}
										very_good = true;									
									}
								break;
								
								case "Wie neu":
									if(as_new == false) 
									{
										if(discount_active == true)
										{
											double tmp_price = Convert.ToDouble(extract_whd_price(offer));
											double final_price = tmp_price * discount_fraction;		
											offers.Add("Wie neu - " + String.Format("{0:0.00}",tmp_price) + Euro + " * " + String.Format("{0:0.00}",discount_fraction) + " = " + String.Format("{0:0.00}",Math.Round(final_price,2)) + Euro);
										}
										else
										{
										offers.Add("Wie neu - " + extract_whd_price(offer) + Euro);
										}
										as_new = true;									
									}
								break;
								
							}
						
						
						}
										
				}
			
				Update_Progressbar(70);
				// get image 
				// you can replace m with s or l
				string imageurl = "http://www.amazon.de/gp/aw/d/"+ASIN+"/?is=m";
				string img = extract_image(get_html_from_url(imageurl));
				Update_Progressbar(90);
				
				// getting idealo if set
				List<string> idealo = new List<string>();
				if(Idealo_Checkbox.Checked == true)
				{
				idealo = get_idealo(name);
				}
				
				// I can't be arsed to use a string builder, sry.
				if(AppendText.Checked == true)
				{
				Output.Text += "[url="+prepare_desktop(ASIN)+TAG+"]"+System.Environment.NewLine+"[img]"+img+"[/img]";
				}
				else
				{
				Output.Text = "[url="+prepare_desktop(ASIN)+TAG+"]"+System.Environment.NewLine+"[img]"+img+"[/img]";
				}
				Output.Text += System.Environment.NewLine;
				Output.Text += name;
				Output.Text += System.Environment.NewLine;
				Output.Text += System.Environment.NewLine;
				Output.Text += price;
				Output.Text += System.Environment.NewLine;
				
				if(Idealo_Checkbox.Checked == true)
				{
					if(idealo.Count == 1)
					{
						Output.Text += idealo[0]+Euro+System.Environment.NewLine;
						if(NewLine_PVL.Checked == true)
						{Output.Text += System.Environment.NewLine;}						
					}
					
					if(idealo.Count > 1)
					{
						foreach(string pvl in idealo)
						{
							Idealo.Text += pvl+Euro+System.Environment.NewLine;
						}
					}
				}
				
				
				foreach(string offer in offers)
				{
					Output.Text += offer;
					Output.Text += System.Environment.NewLine;
				}		
				Output.Text += "[/url]";				
				
				if(AppendText.Checked == true)
				{
					Output.Text += System.Environment.NewLine;
					Output.Text += System.Environment.NewLine;
				}
				
				Update_Progressbar(100);

			
		}
		
		
		void CopyrightClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://mhoffmann.eu");
		}
	}
}
