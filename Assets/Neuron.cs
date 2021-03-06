﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class Neuron{
	public List<int> inputEdges;
	public List<int> outputEdges;
	public int inputCounter;
	public double sumWV;
	public double value;
	public Neuron()
	{
		inputEdges = new List<int> ();
		outputEdges = new List<int> ();
		value = 0.0;
		sumWV = 0.0;
		inputCounter = 0;
	}
	/*public void reset()
		{
			value = 0.0;
			int disabled = 0;
			for (int i=0; i<inputEdges.Count; i++) {
				if (!inputEdges [i].isEnabled) {
					disabled++;
				}
			}
			inputCounter = inputEdges.Count - disabled;
			sumWV = 0.0;
		}*/
	
	
	public void addInput(int e){
		inputEdges.Add (e);
	}
	public void addOutput(int e){
		outputEdges.Add (e);
	}
	
	//adds signal from input, reduces number of inputs not yet added
	public void addValue (double value, double weight){
		sumWV += value * weight;
		inputCounter--;
	}
	
	public void computeValue()
	{
		if (sumWV > 350.0) {
			sumWV = 350.0;
		}
		double e2z = Math.Pow (Math.E, 2.0 * sumWV);
		value = (e2z - 1.0) / (e2z + 1.0);
		//value = 1.0 / (1.0 + Math.Pow (Math.E, -4.9 * sumWV));
		
		
	}
}