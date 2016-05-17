#region License
/*
 * TestSocketIO.cs
 *
 * The MIT License
 *
 * Copyright (c) 2014 Fabio Panettieri
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
#endregion

using System.Collections;
using UnityEngine;
using SocketIO;
using UnityEngine.UI; 
using System.Collections.Generic;

public class TestSocketIO : MonoBehaviour
{
	private SocketIOComponent socket;
	public Text alpha1;
	public Text beta1;
	public Text theta1;
	public Text delta1;
	public Text gamma1;
	public string alpha_string;
	public string[] alphalist;
	public string beta_string;
	public string[] betalist;
	public string theta_string;
	public string[] thetalist;
	public string delta_string;
	public string[] deltalist;
	public string gamma_string;
	public string[] gammalist;
	public string[] separators1 = {"[[", "]]","[","]", ","};
	public void Start() 
	{
		GameObject go = GameObject.Find("SocketIO");

		socket = go.GetComponent<SocketIOComponent>();
		alphalist=new string[8];
		socket.On("open", TestOpen);
		socket.On("bci:fft:alpha", alpha);
		socket.On("bci:fft:beta", beta);
		socket.On("bci:fft:theta", theta);
		socket.On("bci:fft:delta", delta);
		socket.On("bci:fft:gamma", gamma);
		socket.On("error", TestError);
		socket.On("close", TestClose);
		alpha1.text = "";
		beta1.text = "";
		theta1.text = "";
		delta1.text = "";
		gamma1.text = "";
		StartCoroutine("BeepBoop");
	}

	private IEnumerator BeepBoop()
	{
		// wait 1 seconds and continue
		yield return new WaitForSeconds(1);
		
		socket.Emit("hackathon");
		
	
	}

	public void TestOpen(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
	}
	
	public void alpha(SocketIOEvent e)
	{
		alpha_string = e.data [0].ToString();
		alphalist = alpha_string.Split (separators1, System.StringSplitOptions.RemoveEmptyEntries);
		double sum = 0;
		for (int i = 0; i < alphalist.Length; i++)
			sum += double.Parse(alphalist [i]);

		sum = sum / alphalist.Length;

		alpha1.text = sum.ToString ();

		Debug.Log(e.data);


	//	my.text ("[SocketIO] Boop received: " + e.name + " " + e.data);

		if (e.data == null) { return; }

		Debug.Log(
			"#####################################################" +
			"THIS: " + e.data.GetField("this").str +
			"#####################################################"
		);
	}
	public void theta(SocketIOEvent e)
	{
		theta_string = e.data [0].ToString();
		thetalist = theta_string.Split (separators1, System.StringSplitOptions.RemoveEmptyEntries);
		double sum = 0;
		for (int i = 0; i < thetalist.Length; i++)
			sum += double.Parse(thetalist [i]);

		sum = sum / thetalist.Length;
		theta1.text = sum.ToString ();
		Debug.Log(e.data);

		//	my.text ("[SocketIO] Boop received: " + e.name + " " + e.data);

		if (e.data == null) { return; }

		Debug.Log(
			"#####################################################" +
			"THIS: " + e.data.GetField("this").str +
			"#####################################################"
		);
	}
	public void delta(SocketIOEvent e)
	{
		delta_string = e.data [0].ToString();
		deltalist = delta_string.Split (separators1, System.StringSplitOptions.RemoveEmptyEntries);
		double sum = 0;
		for (int i = 0; i < deltalist.Length; i++)
			sum += double.Parse(deltalist [i]);

		sum = sum / deltalist.Length;
		delta1.text = sum.ToString ();

		Debug.Log(e.data);

		//	my.text ("[SocketIO] Boop received: " + e.name + " " + e.data);

		if (e.data == null) { return; }

		Debug.Log(
			"#####################################################" +
			"THIS: " + e.data.GetField("this").str +
			"#####################################################"
		);
	}
	public void beta(SocketIOEvent e)
	{
		beta_string = e.data [0].ToString();
		betalist = beta_string.Split (separators1, System.StringSplitOptions.RemoveEmptyEntries);
		double sum = 0;
		for (int i = 0; i < betalist.Length; i++)
			sum += double.Parse(betalist [i]);

		sum = sum /  betalist.Length;
		beta1.text = sum.ToString ();
		Debug.Log(e.data);

		//	my.text ("[SocketIO] Boop received: " + e.name + " " + e.data);

		if (e.data == null) { return; }

		Debug.Log(
			"#####################################################" +
			"THIS: " + e.data.GetField("this").str +
			"#####################################################"
		);
	}
	public void gamma(SocketIOEvent e)
	{
		gamma_string = e.data [0].ToString();
		gammalist = gamma_string.Split (separators1, System.StringSplitOptions.RemoveEmptyEntries);
		double sum = 0;
		for (int i = 0; i < gammalist.Length; i++)
			sum += double.Parse(gammalist [i]);

		sum = sum / gammalist.Length;
		gamma1.text = sum.ToString ();
		Debug.Log(e.data);

		//	my.text ("[SocketIO] Boop received: " + e.name + " " + e.data);

		if (e.data == null) { return; }

		Debug.Log(
			"#####################################################" +
			"THIS: " + e.data.GetField("this").str +
			"#####################################################"
		);
	}
	public void TestError(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Error received: " + e.name + " " + e.data);
	}
	
	public void TestClose(SocketIOEvent e)
	{	
		Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
	}
}
