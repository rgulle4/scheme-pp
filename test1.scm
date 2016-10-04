; this is a comment line

(display "HeLLo, world! ") ; capitalization of the string should be maintained
(define dAlMatians ; capitalization of identifier should be converted to lowercase
101 )     (define 
     leet1 1337)
(define (foo the-atom the-list) ; this is another comment
	(cond ((null? the-list)  0) ((list? (car the-list)) (+ (foo the-atom (car the-list)) (foo the-atom (cdr the-list)))) ((eqv? (car the-list) the-atom) (+ 1  (foo the-atom (cdr the-list)))) (else (foo the-atom (cdr the-list)))))

