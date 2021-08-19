using System;
using System.Collections.Generic;

namespace GreedyMerge
{
    class Program
    {
        static void Main(string[] args)
        {
            String string1 = "all is well";
            String string2 = "ell that en";
            String string3 = "hat end";
            String string4 = "t ends well";
            String string5 = "AAA"; 
            String string6 = "AAB";
            String string7 = "ABB";
            String string8 = "BBA";
            String string9 = "BBB";

            List<string> fragmentList = new List<string>();
            fragmentList.Add(string1);
            fragmentList.Add(string2);
            fragmentList.Add(string3);
            fragmentList.Add(string4);
            fragmentList.Add(string5);
            fragmentList.Add(string6);
            fragmentList.Add(string7);
            fragmentList.Add(string8);
            fragmentList.Add(string9);


            // iterate through fragment list until only one superstring is left 
            // each iteration matches two fragments and then merges them into a single superstring
            //if not two fragments match then concatenate the first two strings into a single superstring and continue 
            while (fragmentList.Count != 1) {
                int longestmatch = 0; // variable for tracking which two fragments contain the most matches
                String matchingSubString = null; // variable for storing subStrings that match between fragment 1 & 2
                String mergingSubString = null; // variable for storing the subString of the two fragmetns being merged
                String mergingFragment1 = null; // variables for storingof the merging fragments
                String mergingFragment2 = null; 

                // matching algorithm
                // iterate through each fragment in the fragment list and compare it char-by-char to the other fragments
                // contained within the list, determine which two fragments have the most matching charachters (in order!)
                // return the two fragements that have the most matching characthers to merge into the superstring
                foreach (String fragment1 in fragmentList)
                {
                    foreach(String fragment2 in fragmentList)
                    {
                        String subString = ""; // variable for storing the substring and testing for matches between fragment 1 & 2
                        int count = 0; // variable for counting number of matching chars

                        if (fragment1 == fragment2) // dont compare fragments to themselves continue the loop
                        {
                            continue;
                        }
                        else
                        {
                            // iterate through each charachter in fragment1 to find matches with fragment2
                            foreach(Char letter in fragment1)
                            {
                                // build substring from fragment 1 letter by letter
                                subString += letter;

                                // if substring in fragment2 increase match count and store the substring in the matchingsubstring
                                if (fragment2.Contains(subString))
                                {
                                    count++;
                                    matchingSubString = subString;
                                } 
                                else // if substring not in fragment 2 go to the next fragment
                                {
                                    continue;
                                }
                            }
                        }

                        // determine if these two fragments have the most matching characthers
                        // if so store fragments and substring for merging and update longest match
                        if (count > longestmatch)
                        {
                            longestmatch = count;
                            mergingSubString = matchingSubString;
                            mergingFragment1 = fragment1;
                            mergingFragment2 = fragment2;
                        }
                    }
                }

                //merging algorithm 
                String superString = "";

                // ensure that fragments match to some extent. if not then concatenate
                if (longestmatch != 0){

                    int index1 = mergingFragment1.IndexOf(mergingSubString); // stores location of the substring in fragment 1
                    int index2 = mergingFragment2.IndexOf(mergingSubString); // stores location of the substring in fragment 2

                    int range1 = mergingFragment1.Length - mergingSubString.Length; // stores the amount of charachters in fragment 1 not in substring
                    int range2 = mergingFragment2.Length - mergingSubString.Length; // stores the amount of charachters in fragment 2 not in substring

                    // if substring is beginning of fragment 1 but not of fragment 2
                    if ((index1 == 0) && (index2 != 0))
                    {
                        // add the 'leading' portion of fragment 2 before the matching substring occurs
                        superString = mergingFragment2.Substring(0, index2);

                        // add the matching substring 
                        superString += mergingSubString;

                        // if fragment 1 contains trailing characthers not in the substring add them to the end of the superstring
                        if (mergingFragment1.Length != mergingSubString.Length)
                        {
                            superString += mergingFragment1.Substring(mergingSubString.Length, range1);
                        }

                    }
                    // if substring is the beginning of fragment 2 but not fragment 1
                    else if ((index1 != 0) && (index2 == 0))
                    {
                        // add the leading charachters before the substring from fragment 1
                        superString = mergingFragment1.Substring(0, index1);

                        // add the matching substring
                        superString += mergingSubString;

                        // if fragment 2 contains trailing charachters after the matching substring add them to the superstrinf
                        if (mergingFragment2.Length != mergingSubString.Length)
                        {
                            superString += mergingFragment2.Substring(mergingSubString.Length, range2);
                        }
                    } 
                    // if substring occurs at the beginning of BOTH fragment 1 and fragment 2
                    else if ((index1 == 0) && (index2 == 0))
                    {
                        // add the matching characthers to the superstring
                        superString = mergingSubString;

                        // if fragment 1 contains trailing charachters not in the matching substring add them to the end of superstring
                        if (mergingFragment1.Length > mergingSubString.Length)
                        {
                            superString += mergingFragment1.Substring(mergingSubString.Length, range1);
                        }
                        // if fragment 2 contains trailing charachters not in the matching substring add them to the end of superstring
                        if (mergingFragment2.Length > mergingSubString.Length)
                        {
                            superString += mergingFragment2.Substring(mergingSubString.Length, range2);
                        }

                    }

                    // after superstring is constructed 
                    // add superstring to the list and remove the fragments accordingly
                    fragmentList.Add(superString);
                    fragmentList.Remove(mergingFragment1);
                    fragmentList.Remove(mergingFragment2);
                }
                // if no match occurs between the fragments then concatenate the leading most fragments accordingly (the beginning of the list)
                else
                {
                    // concatenate the 2 most leading strings in list 
                    superString = fragmentList[0] + fragmentList[1];

                    // remove fragments from the list 
                    fragmentList.Remove(fragmentList[0]);
                    fragmentList.Remove(fragmentList[0]);

                    // add concatenated string to the list
                    fragmentList.Add(superString);
                }
            }

            // display the resulting message
            Console.WriteLine(fragmentList[0]);
        }
    }
}
