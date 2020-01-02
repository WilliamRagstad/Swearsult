# Swearsult
*Swear words + insult =* **Swearsult**, an esoteric joke language of mere swear words.

It supports both American and British (UK) swear words, censored letters, special symbols (<kbd>!</kbd>,<kbd>.</kbd> & <kbd>,</kbd>) and is not case sensitive.
So for example, the following tokens are valid: `ShiT, piss off you c*nT!!!, bOllOcks, BLOODY heLL... and WANKer`.

## Background

It was invented on December 29, 2019 by [William Rågstad](https://esolangs.org/wiki/User:WilliamRagstad).

# Language overview
A Swearsult program consists of swear words in both the American and British dialect of English together with some [extra words](#extra-words) for the possibility to create understandable sentences. Every line has a number of words separated by spaces. The number of words corresponds to an opcode. Trailing newlines are significant, as an empty line will produce a `0`-opcode.

Instructions are loaded onto the stack and executed there directly, which allows for injecting arbitrary code and executing it through a jump. Self-modifying code is also possible because the program stack is not bounded.

The user is able to supply an input value before executing the program. This input is stored in one of the two registers.

# Grammar

This is an derivative of [Chicken](https://esolangs.org/wiki/Chicken)'s grammar.

| Opcode |    Name     | SwearsultASM Name |                         Description                          |
| :----: | :---------: | :---------------: | :----------------------------------------------------------: |
|  `0`   |    exit     |        die        |                       Stop execution.                        |
|  `1`   | ~~chicken~~ |    ~~chicken~~    |        Push the string "~~chicken~~" onto the stack.         |
|  `2`   |     add     |        add        |                  Add two top stack values.                   |
|  `3`   |  subtract   |       trash       |                Subtract two top stack values.                |
|  `4`   |  multiply   |       bitch       |                Multiply two top stack values.                |
|  `5`   |   compare   |      compare      | Compare two top stack values for equality, push truthy or falsy result onto the stack. |
|  `6`   |    load     |     ~~pick~~      | Double wide instruction. Next instruction indicates source to load from. 0 loads from stack, 1 loads from user input. Top of stack points to address/index to load onto stack. |
|  `7`   |    store    |       push        | Top of stack points to address/index to store to. The value below that will be popped and stored. |
|  `8`   |    jump     |        off        | Top of stack is a relative offset to jump to. The value above that is the condition. Jump only happens if condition is truthy. |
|  `9`   |    char     |       burn        | Interprets the top of the stack as ASCII and pushes the corresponding character. |
| `10+`  |    push     |       fuck        |        Pushes the literal number n-10 onto the stack.        |

## Extra Words

you, your, you're, mom, mother, son, my, i, i'm, the, are, is, it, it's, a, of, off, oh, so, joke, annoyed, annoying, hell, satan and god.

# Examples

## 1. Hello, World!

```
mother fucker son of a bitch rubbish wanker bollocks darn crap mother fucker son of a bitch fucking hell fuck!!!
son of a bitch fuck crap son of a bitch fucking hell fuck shit fuck crap son of a bitch
fuck crap fucking hell!!
son of a bitch crap son of a bitch!!
mother fucker mother fucker son of a bitch fucking hell fuck
son of a bitch fucking hell fuck..
crap son of a bitch fuck crap fucking hell fucks
mother fucker mother fucker, son of a bitch rubbish wanker bollocks darn son of a bitch
fucking hell fuck shit mother fucker mother fucker son of a bitch rubbish wanker bollocks darn
fucking hell crap fuck!
fucking hell, fuck
mother fucker son of a bitch rubbish wanker bollocks darn
fuck crap mother fucker mother fucker son of a bitch rubbish wanker bollocks darn fucking hell fuck!!!!!!!!
fucking hell fuck
mother fucker son of a bitch, rubbish wanker bollocks darn!
fuck crap son of a bitch rubbish wanker bollocks darn
mother fucker mother fucker son of a bitch fucking hell fuck shit fuck
mother fucker mother fucker son of a bitch fucking hell fuck
fucking hell crap mother fucker son of a bitch fucking hell fuck
son of a bitch fucking hell

fucking hell fuck!!!!!!
mother fucker mother fucker son of a bitch rubbish wanker bollocks darn fucking hell
son of a bitch
son of a bitch shit son of a bitch crap mother fucker mother fucker son of a bitch fucking hell fuck!
mother fucker mother fucker son of a bitch rubbish wanker bollocks darn fuck
mother fucker mother fucker son of a bitch rubbish wanker bollocks darn son of a bitch
mother fucker son of a bitch rubbish wanker bollocks darn
mother fucker mother fucker son of a bitch rubbish wanker bollocks darn fucking hell fuck
mother fucker mother fucker son of a bitch rubbish wanker bollocks darn fuck
son of a bitch poop bag fucking hell

son of a bitch
mother fucker son of a bitch rubbish wanker bollocks darn shit son of a bitch fucking hell fuck,
fucking hell
fucking hell
mother fucker son of a bitch fucking hell fuck
mother fucker mother fucker son of a bitch fucking hell fuck
son of a bitch fucking hell

fucking hell
mother fucker mother fucker son of a bitch fucking hell fuck
son of a bitch fucking hell fuck
son of a bitch crap son of a bitch fucking hell fuck
son of a bitch fucking hell

fuck crap son of a bitch fucking hell crap fucking hell fuck
fucking hell fuck
mother fucker mother fucker son of a bitch rubbish wanker bollocks darn!!!
son of a bitch fucking hell fuck
mother fucker mother fucker son of a bitch rubbish wanker bollocks darn.
son of a bitch fucking hell

mother fucker son of a bitch rubbish wanker bollocks darn
mother fucker mother fucker son of a bitch fucking hell fuck crap mother fucker son of a bitch fucking hell fuck mother fucker son of a bitch fucking hell fuck mother fucker son of a bitch fucking hell fuck
fucking hell shit
son of a bitch rubbish wanker bollocks darn
mother fucker mother fucker son of a bitch fucking hell fuck.
son of a bitch fuck shit!!!
```

Output:

```
Hello world
```

