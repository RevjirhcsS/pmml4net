﻿/*
pmml4net - easy lib to read and consume tree model in PMML file
Copyright (C) 2013  Damien Carol <damien.carol@gmail.com>

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Library General Public
License as published by the Free Software Foundation; either
version 2 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Library General Public License for more details.

You should have received a copy of the GNU Library General Public
License along with this library; if not, write to the
Free Software Foundation, Inc., 51 Franklin St, Fifth Floor,
Boston, MA  02110-1301, USA.
 */

using System;

namespace pmml4net
{
	/// <summary>
	/// Description of MissingValueStrategy.
	/// </summary>
	public enum MissingValueStrategy
	{
		/// <summary>
		/// If a Node's predicate evaluates to UNKNOWN while traversing the tree, evaluation is stopped and the current 
		/// winner is returned as the final prediction.
		/// </summary>
		LastPrediction,
		
		/// <summary>
		/// If a Node's predicate value evaluates to UNKNOWN while traversing the tree, abort the scoring process and give no prediction.
		/// </summary>
		NullPrediction,
		
		/// <summary>
		/// If a Node's predicate value evaluates to UNKNOWN while traversing the tree, evaluate the attribute defaultChild 
		/// which gives the child to continue traversing with. Requires the presence of the attribute defaultChild in every non-leaf Node.
		/// </summary>
		DefaultChild,
		
		/// <summary>
		/// If a Node's predicate value evaluates to UNKNOWN while traversing the tree, the confidences for each class is calculated 
		/// from scoring it and each of its sibling Nodes in turn (excluding any siblings whose predicates evaluate to FALSE).
		/// The confidences returned for each class from each sibling Node that was scored are weighted by the proportion of the 
		/// number of records in that Node, then summed to produce a total confidence for each class. The winner is the class with 
		/// the highest confidence. Note that weightedConfidence should be applied recursively to deal with situations where 
		/// several predicates within the tree evaluate to UNKNOWN during the scoring of a case.
		/// </summary>
		WeightedConfidence,
		
		/// <summary>
		/// If a Node's predicate value evaluates to UNKNOWN while traversing the tree, we consider evaluation of the Node's predicate
		/// being TRUE and follow this Node. In addition, subsequent Nodes to the initial Node are evaluated as well. This procedure is 
		/// applied recursively for each Node being evaluated until a leaf Node is reached. All leaf Nodes being reached by this 
		/// procedure are aggregated such that for each value attribute of such a leaf Node's ScoreDistribution element the 
		/// corresponding recordCount attribute values are accumulated. The value associated with the highest recordCount accumulated 
		/// through this procedure is predicted.
		/// The basic idea of missingValueStrategy aggregateNodes is to aggregate all leaf Nodes which may be reached by a record with 
		/// one or more missing values considering all possible values. Strategy aggregateNodes calculates a virtual Node and predicts 
		/// a score according to this virtual Node. Requires the presence of attribute recordCount in all ScoreDistribution elements.
		/// </summary>
		AggregateNodes,
		
		/// <summary>
		/// Comparisons with missing values other than checks for missing values always evaluate to FALSE.
		/// </summary>
		None
	}
}
