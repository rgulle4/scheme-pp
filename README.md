# Scheme Pretty Printer

by: Roy Gullem, Vincent Rodomista

A pretty-printer for a subset of Scheme in C#. Reads a Scheme
program from stdin and prints it properly indented to stdout.

Usage:

```
make && cat test1.scm | mono SPP.exe
```

Given the input file `test1.scm`

```scheme
; this is a comment line

(display "HeLLo, world! ") ; capitalization of the string should be maintained
(define dAlMatians ; capitalization of identifier should be converted to lowercase
101 )     (define 
     leet1 1337)
(define some-list '(alice bob carol))
(define another-list '(alice 'bob carol))
(define (foo the-atom the-list) ; this is another comment
  (cond ((null? the-list)  0) ((list? (car the-list)) (+ (foo the-atom (car the-list)) (foo the-atom (cdr the-list)))) ((eqv? (car the-list) the-atom) (+ 1  (foo the-atom (cdr the-list)))) (else (foo the-atom (cdr the-list)))))
```

the output should be

```scheme
(display "HeLLo, world! ")
(define dalmatians 101)
(define leet1 1337)
(define some-list '(alice bob carol))
(define another-list '(alice 'bob carol))
(define (foo the-atom the-list)
    (cond
        ((null? the-list) 0)
        ((list? (car the-list)) (+ (foo the-atom (car the-list)) (foo the-atom (cdr the-list))))
        ((eqv? (car the-list) the-atom) (+ 1 (foo the-atom (cdr the-list))))
        (else (foo the-atom (cdr the-list)))
    )
)
```

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

For a recursive-descent parser, the grammar must not have left
recursion and common left factors. We also change it to regular BNF
syntax.

```
exp   ->  ( rest
       |  #f
       |  #t
       |  ' exp 
       |  integer_constant
       |  string_constant
       |  identifier

rest  ->  )
       |  exp A 

A     ->  rest
       |  . exp )
```

## References (not in this repo)

| File(s)             | Description                      |
|---------------------|----------------------------------|
| `prog1.bin.Csharp/` | Reference binaries               |
| `prog1.Csharp/`     | Skeleton code                    |
| `proj1.pdf`         | Background info                  |
| `proj1-uml.pdf`     | UML diagram of the skeleton code |
