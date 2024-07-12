# BDD Example

The purpose of this project is to test how BDD will work in practice using a
very simple example but with two 'awkward dependencies': SMTP and a database.

## Scenario

We want to have a service that will listen to nominations made to a particular
point (simplified to ignore the point operator and many other details) and we
want to aggregate all nominations to give a total for each UTC date and per
customer. If the amount reaches above a certain configured threshold, then an
e-mail should be sent to the configured e-mail addresses. The database should
clean up after each day to remove values for dates in the past.

