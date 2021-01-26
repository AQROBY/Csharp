# Implement operator NOT for a binary number
Extend the previous app so now you have another operation included in it.
The new operation should implement the NOT operator upon a binary number.

On the first line the app gets the operation code:
1 - conversion from 10 to base 2
2 - conversion from base 2 to base 10
3 - apply the NOT operator on the entered binary number

On the next line, the number that should be converted will be entered.

Note: The application will show the binary number beggining with the first character that counts. For example, if we apply the NOT operator on the binary number 1100 the result will be 0011. The two 0's from the start of the number are irrelevant and will not be shown. The application should only display '11'.

Example:
Input:
3
101101
Output:
10010

Example:
Input:
3
1021
Output:
A valid binary number was not entered (only 0's and 1's).

Example:
Input:
3
111
Output:
0