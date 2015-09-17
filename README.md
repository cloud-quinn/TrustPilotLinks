# TotallyMoney.com's Trustpilot Unique Link Generator

<a href="http://www.trustpilot.com">Trustpilot</a> is a service that solicits, processes, and stores reviews of your business from your customers. By generating unique links made up of your customers' individual personal and transactional data, you can seamlessly direct them to a suitable survey.

In addition to gaining valuable feedback, you could use their responses in your marketing to improve conversion rates.

<strong><a href="https://www.totallymoney.com">TotallyMoney.com</a>'s Trustpilot Unique Link Generator</strong> takes your customers' details and generates the links for you. Then, all you need to do is e-mail the links to your customers and wait for their feedback.

To generate unique links using this application, you will need a .csv file that looks like this:

<table>
    <tr>
        <td>Customer Name</td>
        <td>Customer E-mail</td>
        <td>Unique Customer ID<sup>1</sup></td>
        <td>Domain Name<sup>2</sup></td>
        <td>Secret Key<sup>3</sup></td>
    </tr>
    <tr>
        <td>"John Doe"</td>
        <td>"test@example.com"</td>
        <td>"CUST2015"</td>
        <td>"mysite.com"</td>
        <td>"mys3cr3tk3y2015"</td>
    </tr>
</table>

<sup>1</sup> Your link must include a unique reference to the customer, such as a customer ID, order ID, or visit ID. Using an Order ID can help you identify which product(s) your customer bought, and when.

<sup>2</sup> Your domain name on Trustpilot, e.g. "mysite.com".

<sup>3</sup> Each domain has its own key which must be kept secret at all times. This key is provided by Trustpilot. To get started, ask your account manager for your secret key.

Alternatively, you can enter all of this information into the form to generate unique links one at a time.

This application, and its code, is free for you to use and adapt, with no restrictions, when creating your own unique links (see further licensing details below). If you would like to develop the code, we recommend you clone this repository and use Visual Studio 2013. If you would like to ask questions, make suggestions, or tell us about improvements you have made to the code, please get in touch at <a href="mailto: feedback@totallymoney.com">feedback@totallymoney.com</a>. 

Created and maintained by <a href="https://www.totallymoney.com">TotallyMoney.com</a>, 2015.

This software is distributed under <strong><a href="https://opensource.org/licenses/MIT">The MIT License (MIT)</a></strong>.

Copyright &copy; 2015 <a href="https://www.totallymoney.com">TotallyMoney.com</a>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
