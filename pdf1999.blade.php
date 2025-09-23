<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>Donation Receipt</title>
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
                <h2 style="text-transform:uppercase;">Sri Annapurna Mandir <br> Charitable Trust</h2>
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

            <td colspan=2 style="border-right:none;border-bottom:none;   border-top:none; width:80%">

                <span style="border-bottom:1px solid #ccc"><strong>Receipt No:</strong>
                    #{{ $donor->receipt_number }}
                    &nbsp; &nbsp; &nbsp; <strong> &nbsp; &nbsp; Date:</strong> {{ $donor->created_at->format('d/m/Y') }}
                    &nbsp; &nbsp; <strong> &nbsp;
                        Time:</strong>{{ $donor->created_at->format('H:i') }}<br /><br /></span>
                <strong>Received With Thanks From:</strong> {{ $donor->donor_name }}
                <br>
                <span><b>In Favour of. </b>{{ $donor->in_favour ?? null }} <br></span>
                <span><b>Address:</b></span> {{ $donor->full_address ?? null }}<br>

            </td>
            <td align="right"style="border-left:none; border-bottom:none; border-top:none; float: right;">
                <p style="text-align:center"><img src="{{ asset('qr.png') }}" alt="QR Code" width="80"><br>
                    <small>Scan & Donate</small>
                </p>
            </td>
        </tr>



        <!-- Donation Amount -->
        <tr>
            <td colspan="3" style="border:1px solid #ddd; background:#eee">
                <strong>For A Sum of Rs:</strong>

                <span id="convertinletters"></span>
                <br>
                <strong>Mode of Payment:</strong>
                {{ $donor->payment_mode }}

                <br>

                <strong>Towards:</strong> {{ $donor->scheme_name ?? null }}
            </td>
        </tr>

        <!-- Gotram and Donation Info -->
        <tr>
            <td colspan="2" style="border-right:none; border-top:none; border-bottom:none">
                <p> <strong>Gotram:</strong> {{ $donor->gotra ?? null }}<br /><br />
                    <span style="border:1px solid #eee; padding:5px;background:#ddd; font-weight:bold">Rs.
                        {{ $donor->donation_amount ?? null }}</span>
                </p><br />
            </td>
            <td style="border-right:none;border-left:none;border-top:none;width:50%; border-bottom:none">
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


        </tr>

        <!-- Tax Info -->
        <tr>
            <td colspan="2" style="border-right:none; border-top:none; width:60%; font-size:12px; background:#eee">
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


    <table width="700" border="1" cellspacing="0" cellpadding="5" align="center"
        style="border-collapse: collapse; border: 1px solid #ccc;">
        <tr align="center">
            <td colspan="2">
                <h3 style="line-height:0px;font-size: 20px; ">श्री अन्नपूर्णा अष्टकम्</h3>
            </td>
        </tr>
        <tr>

            <td align="center">
                <p align="center" style="font-size: 17px;font-weight:600; line-height: 1.2;">
                    @php
                        $number = rand(1, 4);
                    @endphp
                    {{-- @dd($number); --}}
                    @switch($number)
                        @case(1)
                        nityānandakarī varābhayakarī saundarya ratnākarī <br>
                        nirdhūtākhila ghōra pāvanakarī pratyakṣa māhēśvarī । <br><br>
                        prālēyāchala vaṃśa pāvanakarī kāśīpurādhīśvarī <br>
                        bhikṣāṃ dēhi kṛpāvalambanakarī mātānnapūrṇēśvarī ॥ 1 ॥ <br><br>

                        nānā ratna vichitra bhūṣaṇakari hēmāmbarāḍambarī <br>
                        muktāhāra vilambamāna vilasat-vakṣōja kumbhāntarī ।<br><br>
                        @break

                        @case(2)
                            mālā-pustaka-pāśasāṅkuśadharī kāśīpurādhīśvarī<br>
                            bhikṣāṃ dēhi kṛpāvalambanakarī mātānnapūrṇēśvarī <br><br>

                            kṣatratrāṇakarī mahābhayakarī mātā kṛpāsāgarī<br>
                            sarvānandakarī sadā śivakarī viśvēśvarī śrīdharī <br><br>

                            dakṣākrandakarī nirāmayakarī kāśīpurādhīśvarī<br>
                            bhikṣāṃ dēhi kṛpāvalambanakarī mātānnapūrṇēśvarī <br><br>
                        @break

                        @case(3)
                            urvīsarvajayēśvarī bhagavatī [jayakarī] mātā kṛpāsāgarī<br>
                            vēṇī-nīlasamāna-kuntaladharī nityānna-dānēśvarī <br><br>

                            sākṣānmōkṣakarī sadā śubhakarī kāśīpurādhīśvarī<br>
                            bhikṣāṃ dēhi kṛpāvalambanakarī mātānnapūrṇēśvarī <br><br>

                            ādikṣānta-samastavarṇanakarī śambhōstribhāvākarī<br>
                            kāśmīrā tripurēśvarī trinayani viśvēśvarī śarvarī <br><br>
                        @break

                        @case(4)
                            sarva-maṅgaḻa-māṅgaḻyē śivē sarvārtha-sādhikē ।<br>
                            śaraṇyē tryambakē gauri nārāyaṇi namō'stu tē <br><br>

                            sākṣānmōkṣakarī sadā śubhakarī kāśīpurādhīśvarī<br>
                            bhikṣāṃ dēhi kṛpāvalambanakarī mātānnapūrṇēśvarī <br><br>

                            ādikṣānta-samastavarṇanakarī śambhōstribhāvākarī<br>
                            kāśmīrā tripurēśvarī trinayani viśvēśvarī śarvarī <br><br>
                        @break
                    @endswitch

                </p>
            </td>
            <td align="center">
                <p align="center" style="font-size: 17px;font-weight:600; line-height: 1.2;">
 
                    @switch($number)
                        @case(1)
                        yōgānandakarī ripukṣayakarī dharmaikya niṣṭhākarī <br>
                        chandrārkānala bhāsamāna laharī trailōkya rakṣākarī । <br><br>
                        sarvaiśvaryakarī tapaḥ phalakarī kāśīpurādhīśvarī <br>
                        bhikṣāṃ dēhi kṛpāvalambanakarī mātānnapūrṇēśvarī ॥ 3 ॥<br><br>
                        
                        kailāsāchala kandarālayakarī gaurī-hyumāśāṅkarī <br>
                        kaumārī nigamārtha-gōcharakarī-hyōṅkāra-bījākṣarī । <br><br>
                        @break

                        @case(2)
                            dēvī sarvavichitra-ratnaruchitā dākṣāyiṇī sundarī<br>
                            vāmā-svādupayōdharā priyakarī saubhāgyamāhēśvarī <br><br>

                            bhaktābhīṣṭakarī sadā śubhakarī kāśīpurādhīśvarī<br>
                            bhikṣāṃ dēhi kṛpāvalambanakarī mātānnapūrṇēśvarī <br><br>

                            chandrārkānala-kōṭikōṭi-sadṛśī chandrāṃśu-bimbādharī<br>
                            chandrārkāgni-samāna-kuṇḍala-dharī chandrārka-varṇēśvar<br><br>
                        @break

                        @case(3)
                            svargadvāra-kapāṭa-pāṭanakarī kāśīpurādhīśvarī<br>
                            bhikṣāṃ dēhi kṛpāvalambanakarī mātānnapūrṇēśvarī <br><br>

                            dakṣākrandakarī nirāmayakarī kāśīpurādhīśvarī<br>
                            bhikṣāṃ dēhi kṛpāvalambanakarī mātānnapūrṇēśvarī <br><br>

                            annapūrṇē sadāpūrṇē śaṅkara-prāṇavallabhē ।<br>
                            jñāna-vairāgya-siddhyarthaṃ bhikṣāṃ dēhi cha pārvatī <br><br>
                        @break

                        @case(4)
                            dakṣākrandakarī nirāmayakarī kāśīpurādhīśvarī<br>
                            bhikṣāṃ dēhi kṛpāvalambanakarī mātānnapūrṇēśvarī <br><br>

                            annapūrṇē sadāpūrṇē śaṅkara-prāṇavallabhē ।<br>
                            jñāna-vairāgya-siddhyarthaṃ bhikṣāṃ dēhi cha pārvatī <br><br>

                            mātā cha pārvatīdēvī pitādēvō mahēśvaraḥ ।<br>
                            bāndhavā: śivabhaktāścha svadēśō bhuvanatrayam <br><br>
                        @break
                    @endswitch

                </p>
            </td>
        </tr>
    </table>

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
