# Bug report

## BUG-01
```bash
Reproduction steps:
click to 'New registration' link button
```
```bash
Actual behavior:
all input fields are not aligned
```
[click for more information](https://drive.google.com/file/d/1ovQ-0Ib6BsEU1L8grHwF3rMnchom8_Eb/view?usp=sharing)

```bash
Expected behavior:
all input fields should look user-friendly and be align
```
## BUG-02 (automated)
```bash
Reproduction steps:
click to 'New registration' link button
enter registration details without name
	| Name | Surname     | Email                | Phone             |
	|      | Shchepetkov | schepetkov@gmail.com | +31 6 13 96 82 15 |
click to submit button
```
```bash
Actual behavior:
input field name is mandatory
```
[click for more information](https://drive.google.com/file/d/1V7Qj4AOvD29d1WndoL2mpNbuV92VtjOP/view?usp=sharing)

```bash
Expected behavior:
input field name should be optional, accordantly field requirements
```
## BUG-03 (automated)
```bash
Reproduction steps:
click to 'New registration' link button
enter registration details without phone
	| Name | Surname     | Email                | Phone |
	| Dima | Shchepetkov | schepetkov@gmail.com |       |
click to submit button
```
```bash
Actual behavior:
input field phone is mandatory
```
[click for more information](https://drive.google.com/file/d/1dMMfl9RZg11rHMD0vaip5BoD84_6WWQc/view?usp=share_link)

```bash
Expected behavior:
input field phone should be optional, accordantly field requirements
```
## BUG-04 (automated)
```bash
Reproduction steps:
click to 'New registration' link button
enter registration details
	| Name | Surname     | Email                | Phone             |
	| Dima | Shchepetkov | schepetkov@gmail.com | +31 6 13 96 82 15 |
click to submit button
```
```bash
Actual behavior:
phone data is not present in overview section
```
[click for more information](https://drive.google.com/file/d/1YPjTcHd38oQQQ3VJEplwvmkXPCgncl9a/view?usp=share_link)

```bash
Expected behavior:
all user-filled data should be present (unless it's part of the design, it's hard to say without access to the layout)
```
## BUG-05 (automated)
```bash
Reproduction steps:
click to 'New registration' link button
enter registration details
	| Name | Surname     | Email                | Phone             |
	| Dima | Shchepetkov | schepetkov@gmail.com | +31 6 13 96 82 15 |
click to submit button
repeat the previous steps and create the same user
```
```bash
Actual behavior:
app allow to create two the same users
```
[click for more information](https://drive.google.com/file/d/1gHPeHvO20UrK0J_lP0VL_krz5V6NLl4u/view?usp=share_link)

```bash
Expected behavior:
application must validate user data before sending it to the server and avoid the opportunity to create two identical users
```
## BUG-06 (minor)
```bash
Reproduction steps:
click to 'New registration' link button
enter registration details
	| Name | Surname     | Email                | Phone             |
	| Dima | Shchepetkov | schepetkov@gmail.com | +31 6 13 96 82 15 |
click to submit button
resize the screen via dev tools till : 767 px X 841 px
```
```bash
Actual behavior:
the actions (edit and delete) buttons look not user-friendly
```
[click for more information](https://drive.google.com/file/d/103iuOATlgMOV_J4ND4ZB82-ved7S-uVl/view?usp=share_link)

```bash
Expected behavior:
the actions (edit and delete) buttons look user-friendly
keep symmetry and do not overlap
```
## BUG-07 (minor)
```bash
Reproduction steps:
click to 'New registration' link button
```
```bash
Actual behavior:
accordantly documentation email and phone input fields have incorrect names
```
[click for more information](https://drive.google.com/file/d/1d6QU3H5-gb5C4kO_xq7uqgNnI2STi8dh/view?usp=share_link)

```bash
Expected behavior:
change input fields names (on app or in doc)
email - Contact email
phone - Phone number
```
## BUG-08 (automated)
```bash
Reproduction steps:
click to 'New registration' link button
enter registration details with with a large number of characters
	| Name | Surname                                                                                                                                                                                                                                                                                                                                       | Email                | Phone             |
	| Dima | 100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000 | schepetkov@gmail.com | +31 6 13 96 82 15 |
click to submit button
```
```bash
Actual behavior:
user details layout is broken
```
[click for more information](https://drive.google.com/file/d/1wBH8O0AKyveBl6FGP12Tr54tOXxYlypT/view?usp=share_link)

```bash
Expected behavior:
accordantly documentation is no character limit, but it should be
layout should look user-friendly

```
# Test report
[click for view test report](https://drive.google.com/file/d/1ykFsMpZzV0gxchCPjY5u8SeMmAkHt6Oy/view?usp=share_link)