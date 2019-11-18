# QuantumSim
Simple quantum computing simulation implemented in .NET Core, for learning purposes.

You can start at `Qubit.cs`, which provides the following interface:

```C#
public class Qubit
{
    public Qubit(bool b);
    
    public int Id { get; private set; }
    
    public Qstate S { get; private set; }

    public CPoint Peek();

    public bool Measure();
}
```

The `Qubit` get's initialized with a boolean value and has the following properties:

* A unique `Id` used internally for managing its state when it interacts with other qubits.
* A quantum state property `S` of type `Qstate`, which can be exclusive or shared with other qubits. It's made public for debugging purposes.
* A `Peek()` method for evaluating the exclusive internal state of the qubit without collapsing it. If the state is entangled with other qubit this method returns null.
* A `Measure()` method for measuring the qubit boolean value, collapsing its state upon measurement.

OBS: The `Peek()` method currently doesn't support peeking on systems larger than two qubits.

## Operations

There are a few unary and binary operations implemented, such as:

* [Pauli-X gate](https://en.wikipedia.org/wiki/Quantum_logic_gate#Pauli-X_gate) (`XGate.cs`)
* [Pauli-Z gate](https://en.wikipedia.org/wiki/Quantum_logic_gate#Pauli-Z_('%22%60UNIQ--postMath-00000022-QINU%60%22')_gate) (`ZGate.cs`)
* [Hadamard gate](https://en.wikipedia.org/wiki/Quantum_logic_gate#Hadamard_(H)_gate) (`HGate.cs`)
* [Controlled X gate](https://en.wikipedia.org/wiki/Quantum_logic_gate#Controlled_(cX_cY_cZ)_gates) (`CXGate.cs`)
* [Controlled Z gate](https://en.wikipedia.org/wiki/Quantum_logic_gate#Controlled_(cX_cY_cZ)_gates) (`CZGate.cs`)

Simply instantiate a gate and apply it to one or two qubits:

```C#
[TestMethod()]
public void DirectEntanglementTest()
{
    var q1 = new Qubit(false);
    var q2 = new Qubit(false);

    new HGate().Apply(q1);
    new CXGate().Apply(q1, q2);

    if (q1.Measure() != q2.Measure())
        Assert.Fail();
}
```

## Licensing

This code is released under the MIT License:

Copyright (c) TCGV.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
