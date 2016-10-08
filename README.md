# Scheme Pretty Printer

by: Roy Gullem, Vincent Rodomista

A pretty-printer for a subset of Scheme in C#. Reads a Scheme
program from stdin and prints it properly indented to stdout.

## The basic grammar

The recursive descent parser will only need to recognize the
following grammar:

```
exp  ->  ( rest
      |  #f
      |  #t
      |  ' exp
      |  integer_constant
      |  string_constant
      |  identifier

rest  ->  )
       |  exp+ [ . exp  ] )
```

## The transformed grammar

TODO: transform our grammar by removing left recursion and common
left factors.

Some simple examples:

```
// -- LEFT RECURSION ------------------------ //

X  ->  a
    |  X b

-- inspect derived strings... -----------
-- then write as right-recursive --------

X  ->  a B
B  -> 
    |  b B
```

```
// -- COMMON LEFT FACTORS ------------------- //

X  ->  a Y
    |  a Z

-- add a new non-terminal for common a --

X  ->  a T
T  ->  Y
    |  Z

```

```
// -- JAVA EXAMPLE ----------- //

    <Decl>       ->   <VarDecl>
                  |   <ClassDecl>

    <VarDecl>    ->   <Modifiers>  <Type>  <VarDec>  SEM

    <ClassDecl>  ->   <Modifiers> CLASS ID LBRACE <DeclList> RBRACE

    <DecList>    ->   <Decl>
                  |   <DecList> <Decl>

    <VarDec>     ->   ID
                  |   ID Assign <Exp>
                  |   <VarDec> COMMA ID
                  |   <VarDec> COMMA ID ASSIGN <Exp>

-------------------

    <Decl>       ->  Modifiers <DeclRest>
    
    <DeclRest>   ->  <VarDecl>
                  |  <ClassDecl>
    
    <VarDecl>    ->  Type <VarDec> SEM
    
    <ClassDecl>  ->  CLASS ID LBRACE <DeclList> RBRACE
    
    <DeclList>   ->  <Decl> <DLRest>
    
    <DLRest>     ->  epsilon
                 ->  <DeclList>
    
    <VarDec>     ->  ID <OptAssign> <VarDecRest>
    
    <OptAssign>  ->  epsilon
                  |  ASSIGN <Exp>

    <VarDecRest> ->  epsilon
                  |  COMMA <VarDec>
```

## References (not in this repo)

| File(s)             | Description                      |
|---------------------|----------------------------------|
| `prog1.bin.Csharp/` | Reference binaries               |
| `prog1.Csharp/`     | Skeleton code                    |
| `proj1.pdf`         | Background info                  |
| `proj1-uml.pdf`     | UML diagram of the skeleton code |
