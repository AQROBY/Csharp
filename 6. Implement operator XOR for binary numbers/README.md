# Implement operator XOR for a binary number or two binary numbers
Extend the previous app so now you have another operation included in it.
The new operation should implement the XOR operator upon a binary number.

On the first line the app gets the operation code:

1 - conversion from 10 to base 2

2 - conversion from base 2 to base 10

3 - apply the NOT operator on the entered binary number

4 - apply the OR operator on the entered binary number(s)

5 - apply the AND operator on the entered binary number(s)

6 - apply the XOR operator on the entered binary number(s)

On the next line(s), the number or numbers will be entered, upon which the XOR operator will be executed (a number on each line).

Note: If the binary numbers have a different number of figures, they will be aligned towards the right. The figures of the shorted number that are missing will be considered as '0' so that both numbers will have the same length.

Example:
Input:
6
10100
111 => this will mean 10100 XOR 00111

Output:
10011

Example:
Input:
6
1010
1100

Output:
110