; this is a comment line
(define quoted-list (quote (1 . 2)))
(display "HeLLo, world! ") ; capitalization of the string should be maintained
(define dAlMatians ; capitalization of identifier should be converted to lowercase
101 )     (define
     leet1 1337)
(a b c) (d (e f) g h)
(define some-list (quote (alice bob carol)))
(define another-list '(alice 'bob carol))
(define (foo the-atom the-list) ; this is another comment
	(cond ((null? the-list)  0) ((list? (car the-list)) (+ (foo the-atom (car the-list)) (foo the-atom (cdr the-list)))) ((eqv? (car the-list) the-atom) (+ 1  (foo the-atom (cdr the-list)))) (else (foo the-atom (cdr the-list)))))
(define (fac n)
(if (= n 0) 1 (* n (fac (- n 1)))))
;(define (fac n)
		;(y 5))
	;(* x y))
;(let ((x 3)
(define some-list '(coffee tea))
(if (= n 0) 1 (b* n (fac (b- n 1))))
(fac 5)
(begin (set! x 5) (+ x 1)) 
((lambda (x y) (* x y)) 3 5)
