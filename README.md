# Documentation

Text Converter for Design Patterns course.

Convert text from the **very special** format to common special formats such as:
* HTML
* Markdown

![screenshot](https://github.com/TezRomacH/CS361-DP-collaboration-1/blob/master/TextConverter_screenshot.png)


**The very special format of source text.** Text consists of paragraphs splitted by one or more new lines. Each paragrah starts with keyword and one space, and the rest of the paragraph is the text.

Keywords here:

* ```p``` - plain text
* ```h1``` - header 1
* ```h2``` - header 2
* ```h3``` - header 3
* ```ordlist``` - numbered list
* ```bullist``` - bulleted list

Example, source text:
```
h1 Header 1

p Hello, world!

p Attention!
The numered list:

ordlist ignored text
item 1;
item 2;
item 3.

h2 Header 2

Ignored text without keyword

p Bulleted list:

bullist
item 1;
item 2.

h1 The end!
```

Converted to markdown:

```md
# Header 1 #

Hello, world!

Attention!
The numered list:

1. item 1;
1. item 2;
1. item 3.

## Header 2 ##

Bulleted list:

* item 1;
* item 2.

# The end! #
```

# UML diagram

![UMl Diagram](https://github.com/TezRomacH/CS361-DP-collaboration-1/blob/master/uml.png)

# Design Patterns
Builder pattern.

Builder separates the construction of a complex object from its representiong so that the same construction process can create different representations

Abstract interface: ConverterBulder

Concrete implementations: HtmlBuilder, MarkdownBuilder

The Builder pattern is the best choice between creational patterns here. We have an abstraction such as markup language. It consists of the "parts" - headers, plain text, lists. So we define an interface for any markup language and implement builders for concrete languages.

# Developers
Roman Tezikov: 
* designed interface according to patterns
* implement Parser
* build GUI
* write unit test for builders

Tatiana Popova:
* implement HtmlBuilder, MarkdownBuilder
* re-think Parser design, separate converting and parsing
* localize application. Supported languages: English, Russian 
* write unit tests for Parser
