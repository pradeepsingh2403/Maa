<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>.</title>
    <script src="{{ asset('cnd/jquery-3.6.0.min.js') }}"></script>
    <script>
        function numberToWords(num) {
            const ones = ["", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"];
            const teens = ["Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
                "Sixteen", "Seventeen", "Eighteen", "Nineteen"
            ];
            const tens = ["", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"];
            const thousands = ["", "Thousand", "Lakh", "Crore"];

            function convertLessThanThousand(n) {
                let str = "";
                if (Math.floor(n / 100) > 0) {
                    str += ones[Math.floor(n / 100)] + " Hundred";
                    n %= 100;
                    if (n) str += " ";
                }
                if (n >= 10 && n < 20) {
                    str += teens[n - 10];
                } else {
                    if (Math.floor(n / 10) > 1) {
                        str += tens[Math.floor(n / 10)];
                        if (n % 10) str += " " + ones[n % 10];
                    } else if (n % 10) {
                        str += ones[n % 10];
                    }
                }
                return str.trim();
            }

            function convert(num) {
                if (num === 0) return "Zero Rupees";

                let parts = [];
                const numStr = num.toString().padStart(9, "0"); // up to 99,99,99,999
                const crore = parseInt(numStr.substr(0, 2));
                const lakh = parseInt(numStr.substr(2, 2));
                const thousand = parseInt(numStr.substr(4, 2));
                const hundred = parseInt(numStr.substr(6, 3));

                if (crore) parts.push(convertLessThanThousand(crore) + " Crore");
                if (lakh) parts.push(convertLessThanThousand(lakh) + " Lakh");
                if (thousand) parts.push(convertLessThanThousand(thousand) + " Thousand");
                if (hundred) parts.push(convertLessThanThousand(hundred));

                return parts.join(" ") + " Rupees";
            }
            var converted = convert(num);

            document.getElementById("convertinletters").innerHTML = converted;
            document.getElementById("convertinletters2").innerHTML = converted;
        }
    </script>
</head>

<body style="font-family: Arial, sans-serif; font-size: 12px; line-height: 1.2; color: #000;">
    <table width="700" border="1" cellspacing="0" cellpadding="5" align="center"
        style="border-collapse: collapse; border: 1px solid #ccc;">

        <!-- Header Section -->
        <tr>
            <td align="left" style="border:none" colspan="3">


            </td>
        </tr>
        <tr>
            <td valign="middle" align="center" style="  border:none; width:40%; background:#ddd">
                <h2 style="text-transform:uppercase">Sri Annapurna Mandir <br> Charitable Trust</h2>
            </td>
            <td align="center" style=" border:none; width:20%; background:#ddd">
                <img src="{{ asset('frontend/Goddess.jpg') }}" style="height: 90px;" alt="">
            </td>
            <td valign="middle" align="center" style=" border:none; background:#ddd">
                <p>Sri Annapurna Math Temple, D9/1, Vishwanath Lane,<br>Varanasi-221001 (U.P.), India
                    <br />Ph: 0542-2392619 , 8795777588 , <br /> 9794214449
                </p>
            </td>
        </tr>
        <!-- Receipt Info -->
        <tr>
            <td colspan=3 align="center" style="border:none"> <u><i> <b>DONATION RECEIPT</b></i></u></td>
        </tr>
        <tr>

            <td colspan=2 style="border-right:none;border-bottom:none;padding-left:15px;   border-top:none; width:90%">

                <span style="border-bottom:1px solid #ccc;"><strong>Receipt No:</strong>
                    #{{ $donor->receipt_number }}
                    &nbsp; <strong> &nbsp; Date:</strong> {{ $donor->created_at->format('d/m/Y') }}
                    &nbsp; &nbsp; &nbsp; &nbsp; <strong>
                        Time:</strong>&nbsp; {{ $donor->created_at->format('H:i') }}<br /><br /></span>
                <strong>Donor Name:</strong> {{ $donor->donor_name }}</strong>
                <br>
                <span>Annadanam In Favour of. <b>{{ $donor->in_favour ?? null }}</b> <br></span>
                <span><b>Address:</b> {{ $donor->full_address ?? null }}</span>
                <br>
                <span>
                    Annadanam has to be performed on <b>{{ $donor->ritual_performing_date ?? null }}</b></span>

            </td>
            <td align="right"style="border-left:none; border-bottom:none; border-top:none; float: right;">
                <p style="text-align:center"><img src="{{ asset('qr.png') }}" alt="QR Code" width="80"><br>
                    <small>Scan & Donate</small>
                </p>
            </td>
        </tr>



        <!-- Donation Amount -->
        <tr>
            <td colspan="3" style="border:1px solid #ddd; background:#eee;padding-left:10px">
                <strong>For A Sum of Rs:</strong>

                <span id="convertinletters"></span>
                <br>
                <strong>Mode of Payment:</strong>
                {{ $donor->payment_mode }}
                <br>
                <br>
                <strong>Donation Date:</strong>{{ $donor->donation_date ?? null }}<br>

                <strong>Towards:</strong> {{ $donor->scheme_name ?? null }}
            </td>
        </tr>

        <!-- Gotram and Donation Info -->
        <tr>
            <td colspan="2" style="border-right:none; border-top:none; border-bottom:none;padding-left:10px">
                <p> <strong>Gotram:</strong> {{ $donor->gotra ?? null }}<br /><br />
                    <span style="border:1px solid #eee; padding:5px;background:#ddd; font-weight:bold">Rs.
                        {{ $donor->donation_amount ?? null }}</span>
                </p><br />
            </td>
            <td style="border-right:none;border-left:none;border-top:none;width:50%; border-bottom:none;">
                @if ($donor->mobile_number != null)
                    <strong>Phone/Cell No.:</strong>{{ $donor->mobile_number ?? null }}<br>
                @endif

                @if ($donor->id_type == 'Aadhar Card')
                    <strong>Donor {{ $donor->id_type }}.:</strong>{{ $donor->id_number }}
                @endif
                @if ($donor->id_type == 'PAN Card')
                    <strong>Donor {{ $donor->id_type }}.:</strong> {{ $donor->id_number }}
                @endif
                @if ($donor->id_type == 'Voter ID')
                    <strong>Donor {{ $donor->id_type }}.:</strong>{{ $donor->id_number }}
                @endif
            </td>

            {{-- <td style="border-left:none; width:39%;border-top:none; border-bottom:none">
                <span style="border:2px solid #ccc; padding:5px; float:left;">
                    <strong><u>Annadana Scheme Timings</u></strong><br /><br />
                    <strong> Refreshment:</strong> 7:00 A.M. to 10:30 A.M.<br>
                    <strong> Free Meals:</strong> 11:00 A.M. to 5:00 P.M.<br>
                    <strong> Naravan Seva:</strong> 11:00 P.M. to 2:00 A.M.
                    <span>
            </td> --}}
        </tr>

        <!-- Tax Info -->
        <tr>
            <td colspan="2"
                style="border-right:none; border-top:none; width:60%; font-size:12px; background:#eee;padding-left:15px;">
                <span style="font-size:10px; font-weight:bold"> Regd.under Sec.80G of Income Tax act 1962 vide URN
                    No.ABATS9206RF20241 DATED 16-10-2024<br />
                    TRUST PAN NO.: AABTS9206R
                    <br>
                    TAN NO.: ALDS12839B
                    <br>
                    DARPAN ID.: UP/2025/0539820</span>

            </td>


            <td style="border-left:none; border-top:none; width:40%; background:#eee">
                <br /><br /><br />
                For:<br />
                <p style="text-align:center"> Chief Trustee, <br />
                    Sri Annapurna Mandir Charitable Trust <br />
                    Varanasi 221001 (U.P.)</p>
            </td>

        </tr>
        <tr>
            <td colspan="3" style="text-align:center">
                <b>GODDESS ANNAPURNA BLESS YOU</b>

            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align:center">
                <b>Email:</b> Kashiannapurnacharitabletrust@gmail.com
                <b>Website:</b> www.kashiannapurnatemple.com
            </td>
        </tr>




    </table>

    <!-- Sanskrit Shloka Section (optional, or can be added in another table) -->
    <br>


    <table width="700" border="1" cellspacing="0" cellpadding="1" align="center"
        style="border-collapse: collapse; border: 1px solid #ccc;">
        <tr>
            <td>
                <div class="receipt-signature-block">
                    <h2 style="margin-top:5px;padding-top:5px;text-decoration: underline; ">
                        ANNADATA CERTIFICATE<br>
                    </h2>
                </div>
            </td>
        </tr>
        <tr>

            <td align="center">
                <div style="margin-top:10px !important;" class="receipt-signature-section">
                    <div class="">
                        <b>Recipt No:</b> #{{ $donor->receipt_number ?? null }}
                    </div>
                    <div class="receipt-signature-block">
                        <b> Date:</b> {{ $donor->created_at->format('d-m-Y') }}
                    </div>
                    <div class="receipt-signature-block">
                        <b> Time:</b> {{ $donor->created_at->format('H:i') }}
                    </div>
                </div>

            </td>
        </tr>
    </table>
    <table width="700" border="1" cellspacing="0" cellpadding="5" align="center"
        style="border-collapse: collapse; border: 1px solid #ccc;">
        <tr>
            <td align="center">
                <table class="receipt-table">
                    <tbody>
                        <tr>
                            <td colspan="2" class="receipt-label receipt-td" style="padding-left:10px">Donor name:
                                <span class="receipt-bold"
                                    style="font-weight:normal">{{ $donor->donor_name ?? null }}</span>
                            </td>

                            <td colspan="1" rowspan="8" class="receipt-image-container receipt-td"
                                style="text-align:right">
                                <img style="max-height:80px"
                                    alt="Black and white photo of a temple with people and street view"
                                    class="receipt-image" src="{{ asset('cnd/img2.jpg') }}" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="receipt-label receipt-td" style="padding-left:10px">Address: <span
                                    style="font-weight:normal ; text-wrap:auto">{{ $donor->full_address ?? null }} </span></td>
                            <td class="receipt-td"></td>
                        </tr>

                        <tr>
                            <td colspan="3" class="receipt-td" style="padding-top: 0px; padding-left:10px">
                                <p style="font-size:11px; font-weight:bold"> We are very much pleased to received a sum
                                    Rs. <span class="receipt-bold">{{ $donor->donation_amount ?? null }}</span>

                                    <span style="margin-left: 48px;">( Rupees. <span id="convertinletters2"
                                            class="receipt-uppercase">

                                        </span>)
                                    </span>
                                    through {{ $donor->payment_mode ?? null }} towards Annadanam to be performed in
                                    favour of <span class="receipt-bold">{{ $donor->donor_name ?? null }}</span> On
                                    <span class="receipt-bold">{{ $donor->ritual_performing_date ?? null }},</span>
                                    in the holy Kashi Annapurna Devi Temple premises. This donation is very precious for
                                    the
                                    welfare of the society have peace and prosperity with the blessings of goddess Sri
                                    Kashi
                                    Annapurna Devi.
                                </p>

                            </td>
                        </tr>
                        <!-- Tax Info -->
                        <tr>
                            <td colspan="1"
                                style="border-right:none; border-top:none;  font-size:11px; padding-left:10px;">
                                <b>DONOR CELL NO:-</b> {{ $donor->mobile_number ?? null }}<br />
                                <!-- <b>GODDESS ANNAPURNA BLESS YOU</b> -->
                            </td>


                            <td colspan="2"
                                style="border-left:none;width:50%; border-top:none; background:#fff; font-size:11px; font-weight:bold">

                                For:<br />
                                <p style="text-align:center"> Chief Trustee, <br />
                                    Sri Annapurna Mandir Charitable Trust <br />
                                    Varanasi 221001 (U.P.)</p>
                            </td>

                        </tr>


                    </tbody>
                </table>


            </td>
    </table>



















    <style>
        .receipt-container {
            max-width: 768px;
            margin: 0 auto;
            border: 1px solid #d1d5db;
            padding: 24px;
            box-sizing: border-box;
        }

        .receipt-table {
            width: 100%;
            border-collapse: collapse;
            font-size: 14px;
            line-height: 1.5;
        }

        .receipt-td {
            vertical-align: top;
            padding: 2px 8px 8px 0;
        }

        .receipt-label {
            font-weight: 700;
            white-space: nowrap;
            width: 140px;
        }

        .receipt-bold {
            font-weight: 700;
        }

        .receipt-uppercase {
            text-transform: uppercase;
        }

        .receipt-right {
            text-align: right;
        }

        .receipt-image-container {
            width: 120px;
            height: 120px;
            text-align: right;
            padding-left: 16px;
        }

        .receipt-image {
            width: 120px;
            height: 120px;
            object-fit: cover;
            display: inline-block;
        }

        .receipt-signature-section {
            padding: 0px 15px;
            margin-top: 72px;
            font-size: 12px;
            display: flex;
            justify-content: space-between;
            gap: 96px;
        }

        .receipt-signature-block {
            text-align: center;
            line-height: 1.4;
        }

        .receipt-signature-name {
            font-style: italic;
            font-size: 18px;
            margin-bottom: 40px;
        }

        .receipt-footer {
            margin-top: 72px;
            font-size: 12px;
        }

        @media (max-width: 700px) {
            .receipt-container {
                margin: 12px;
                padding: 16px;
            }

            .receipt-signature-section {
                flex-direction: column;
                gap: 24px;
                align-items: flex-start;
            }

            .receipt-image-container {
                text-align: left;
                padding-left: 0;
                margin-top: 16px;
            }

            .receipt-td {
                display: block;
                padding: 2px 0;
            }

            .receipt-label {
                display: inline-block;
                width: auto;
                font-weight: 700;
            }
        }
    </style>

    <script>
        $(window).on('load', function() {
            numberToWords('{{ (int) $donor->donation_amount }}');
            window.print();
        });

        // Go back after printing
        window.onafterprint = function() {
            window.location.href = '/admin/donation/add';
        };
    </script>
</body>

</html>
