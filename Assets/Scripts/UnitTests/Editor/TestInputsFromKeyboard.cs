using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using UnityStandardAssets.CrossPlatformInput;
using NSubstitute;
using System;

public class TestInputsFromKeyboard {
    //mock a interfaceforinputcontroller
    public IplayerInputController fakeInput = Substitute.For<IplayerInputController>();
    public playerInputController input;
    
//all our expected and actual values
    float Expectedx = 1.0f;
    float Expectedz = 1.0f;
    float Expectedh = 1.0f;
    float Expectedv = 1.0f;
    float Expectedf = 1.0f;
    float Expectedx2 = -1.0f;
    float Expectedz2 = -1.0f;
    float Expectedh2 = -1.0f;
    float Expectedv2 = -1.0f;
    float Actualx;
    float Actualz;
    float Actualh;
    float Actualv;
    float Actualf;

    //testing WASD inputs
    [Test]
    public void TestWVerticalAxis()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<playerInputController>();
        input = testObject.GetComponent<playerInputController>();
        fakeInput.GetAxisRaw(Arg.Is("Vertical")).Returns(1.0f);
        input.InputInterface = fakeInput;
        input.getCurrentInput();
        Actualv = input.Movev;
        Assert.AreEqual(Expectedv, Actualv, "Testing W: ");
    }

    [Test]
    public void TestSVerticalAxis()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<playerInputController>();
        input = testObject.GetComponent<playerInputController>();
        fakeInput.GetAxisRaw(Arg.Is("Vertical")).Returns(-1.0f);
        input.InputInterface = fakeInput;
        input.getCurrentInput();
        Actualv = input.Movev;
        Assert.AreEqual(Expectedv2, Actualv, "Testing S: ");
    }

    [Test]
    public void TestAHorizontalAxis()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<playerInputController>();
        input = testObject.GetComponent<playerInputController>();
        fakeInput.GetAxisRaw(Arg.Is("Horizontal")).Returns(1.0f);
        input.InputInterface = fakeInput;
        input.getCurrentInput();
        Actualh = input.Moveh;
        Assert.AreEqual(Expectedh, Actualh, "Testing A: ");
    }

    [Test]
    public void TestDHorizontalAxis()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<playerInputController>();
        input = testObject.GetComponent<playerInputController>();
        fakeInput.GetAxisRaw(Arg.Is("Horizontal")).Returns(-1.0f);
        input.InputInterface = fakeInput;
        input.getCurrentInput();
        Actualh = input.Moveh;
        Assert.AreEqual(Expectedh2, Actualh, "Testing D: ");
    }


    //Testing Arrow key inputs
    [Test]
    public void TestUPVerticalAxis()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<playerInputController>();
        input = testObject.GetComponent<playerInputController>();
        fakeInput.GetAxisRaw(Arg.Is("VerticalLook")).Returns(1.0f);
        input.InputInterface = fakeInput;
        input.getCurrentInput();
        Actualx = input.Lookv;
        Assert.AreEqual(Expectedx, Actualx, "Testing UP: ");
    }

    [Test]
    public void TestDOWNVerticalAxis()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<playerInputController>();
        input = testObject.GetComponent<playerInputController>();
        fakeInput.GetAxisRaw(Arg.Is("VerticalLook")).Returns(-1.0f);
        input.InputInterface = fakeInput;
        input.getCurrentInput();
        Actualx = input.Lookv;
        Assert.AreEqual(Expectedx2, Actualx, "Testing DOWN: ");
    }

    [Test]
    public void TestLEFTHorizontalAxis()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<playerInputController>();
        input = testObject.GetComponent<playerInputController>();
        fakeInput.GetAxisRaw(Arg.Is("HorizontalLook")).Returns(1.0f);
        input.InputInterface = fakeInput;
        input.getCurrentInput();
        Actualz = input.Lookh;
        Assert.AreEqual(Expectedz, Actualz, "Testing LEFT: ");
    }

    [Test]
    public void TestRIGHTHorizontalAxis()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<playerInputController>();
        input = testObject.GetComponent<playerInputController>();
        fakeInput.GetAxisRaw(Arg.Is("HorizontalLook")).Returns(-1.0f);
        input.InputInterface = fakeInput;
        input.getCurrentInput();
        Actualz = input.Lookh;
        Assert.AreEqual(Expectedz2, Actualz, "Testing RIGHT: ");
    }

    [Test]
    public void TestFireAxis()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<playerInputController>();
        input = testObject.GetComponent<playerInputController>();
        fakeInput.GetAxisRaw(Arg.Is("Fire1")).Returns(1.0f);
        input.InputInterface = fakeInput;
        input.getCurrentInput();
        Actualf = input.f;
        Assert.AreEqual(Expectedf, Actualf, "Testing FIRE: ");
    }








}
