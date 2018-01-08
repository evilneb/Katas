Ben Levy - Game of Life technical kata submission

This was made using C# in Visual Studio 2017 and should be run 
in the same or similar environment. 
It started with a pretty basic, static structure, but I kept
having more and more fun with it. Once I got the neighbor counting
algorithm working, I realized it should be perfectly functional
on any size 2d array, and of course decided to try that. As it's a
console app, this can be a little clunky, and asking the
user to define the array dimensions first didn't feel great
to me. Instead, I decided to make it completely freeform entry,
so that the user can whimsically type whatever initial state they'd
like to see, dead cells being ' '(space) characters. On top of
that, I thought it would be interesting to be able to use any characters
at all in the entry of the initial state. This has a side effect of
making the tediousness of console text entry a little less so, as 
you can just mash whatever jumbles of characters you'd like with spaces
separating. The caveat to this is the condition where a !Alive cell 
changes its state to Alive. How will it know what character to use? 
I could have just used any random character, but that didn't seem very 
fun, so I instead had each (Organism) object store the characters of its 
neighbors and choose randomly from those. The effect of this is a gradual
homogenization of characters remaining in the world as the state changes
are run repeatedly, which was pretty satisfying and interesting to see.
There's definitely some more optimizing I think could be done (which I
may pursure in the future) but this seemed like a good place to end the
project for now.
