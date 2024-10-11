# NETLab4

Lab 4 | Design Patterns (Structural) | Composite

Muzyka Stefan
IS-02
Variant 11

## Task
Implement a parse tree for an expression, based on the following syntax rules:
```
<expression> ::= <simple expression> | <complex expression>
<simple expression> ::= <constant> | <variable>
<constant> ::= (<number>)
<variable> ::= (<name>)
<complex expression> ::= (<expression> <operator> <expression>)
<operator> ::= + | - | * | /
```

## Explanation

Here’s the English translation of your text:

# NETLab4

Lab 4 | Design Patterns (Structural) | Composite

Muzyka Stefan
IC-02
Variant 11

## Explanation
The Composite pattern is implemented through the classes Component, Composite, and Leaf. They represent a tree-like structure of an expression.

- Component is an abstract class that describes a part of the expression (either complex or simple).
- Composite is a complex expression.
- Leaf represents a simple expression (a constant or variable).
- Connect is the class that describes mathematical operators (*, /, +, -).
- Part is an abstract class that describes types of data: Number for constants and Variable for variables.
The expression is converted into an expression tree by the static class ExpressionParser.

## Class Diagram
![Untitled Diagram drawio](https://user-images.githubusercontent.com/76735417/186913289-42efdcc1-5aef-4beb-b25f-fd1b8bc08661.png)
