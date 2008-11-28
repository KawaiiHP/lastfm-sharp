// AlbumSearch.cs
//
//  Copyright (C) 2008 Amr Hassan
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
//
//

using System;
using System.Xml;
using System.Collections.Generic;

namespace Lastfm.Services
{
	/// <summary>
	/// Encapsulates the album searching functions.
	/// </summary>
	/// <remarks>
	/// To create an object of this class use <see cref="Search.ForAlbums"/>.
	/// </remarks>
	public class AlbumSearch : Search
	{
		internal AlbumSearch(Dictionary<string, string> searchTerms, Session session, int itemsPerPage)
			:base("album", searchTerms, session, itemsPerPage)
		{}
		
		/// <summary>
		/// Returns a page of results.
		/// </summary>
		/// <param name="page">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <returns>
		/// A <see cref="Album"/>
		/// </returns>
		public Album[] GetPage(int page)
		{
			RequestParameters p = getParams();
			p["page"] = page.ToString();
			
			lastDoc = request("album.search", p);
			
			List<Album> list = new List<Album>();			
			foreach(XmlNode n in lastDoc.GetElementsByTagName("album"))
				list.Add(new Album(extract(n, "artist"), extract(n, "name"), Session));
			
			return list.ToArray();
		}
	}
}
