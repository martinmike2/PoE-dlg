﻿/*******************************************************************************
 * Copyright 2015 Valentin Milea
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 ******************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PoEDlgExplorer.XmlModel
{
	public enum BankNodePlayType
	{
		PlayFirst,
		PlayAll,
		PlayRandom
	}

	[Serializable]
	public class BankNode : FlowChartNode
	{
		public BankNodePlayType BankNodePlayType;
		public List<int> ChildNodeIDs;

		[XmlIgnore]
		public override IReadOnlyList<int> ChildIDs
		{
			get { return ChildNodeIDs; }
		}

		protected override void ExtendBrief(StringBuilder sb)
		{
			sb.Append(BankNodePlayType).Append(" ");
			sb.Append(ChildNodeIDs.Count).Append("-children ");
		}
	}
}
