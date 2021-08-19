
s1 = "all is well"
s2 = "ell that en"
s3 = "hat end"
s4 = "t ends well"
s5 = "AAA"
s6 = "AAB"
s7 = "ABB"
s8 = "BBA"
s9 = "BBB"
s10 = "abxy"
s11 = "xyab"

fragementlist = [s1,s2,s3,s4, s5,s6,s7,s8,s9]

# iterate through fragment list until only one superstring is left 
# each iteration matches two fragments and then merges them into a single superstring
# if not two fragments match then concatenate the first two strings into a single superstring and continue 
while len(fragementlist) > 1:
    longestmatch = 0 # variable for determining which fragements have the most matching charachters in each loop
    matching_substring = '' # variable used to test substrings in each fragments
    merging_substring = '' # the substring that is contained within both merging fragements
    mergingfrag1 = '' # fragment 1 to merge 
    mergingfrag2 = '' # fragement 2 to merge

    # matching algorithm
    # iterate through each fragment in the fragment list and compare it char-by-char to the other fragments
    # contained within the list, determine which two fragments have the most matching charachters (in order!)
    # return the two fragements that have the most matching characthers to merge into the superstring
    for fragment1 in fragementlist:
        for fragment2 in fragementlist:
            substring = '' # variable to store the substring (used to determine matching fragments)
            count = 0 # variable to determine the amount of matching charachters between two fragments

            if fragment1 == fragment2: 
                continue # dont compare a fragment to itself
            else:
                # iterate through each characther in a fragment to determine matching substrings
                for letter in fragment1:
                    # construct a substring used to identify matching fragments
                    substring += letter
                    
                    # if the substring is in fragment 2 then increase the matching characther count by 1
                    if (substring in fragment2):
                        matching_substring = substring # update the matching substring 
                        count += 1
                    else:
                        continue
            
            # if two fragments have the most matching charachters then set them as the fragments to merge
            if count > longestmatch:
                longestmatch = count
                merging_substring = matching_substring
                mergingfrag1 = fragment1
                mergingfrag2 = fragment2

    # merging algorithm
    superstring = ""

    # ensure that merging fragmetns have a matching substring
    if (longestmatch != 0): 
        # determine the index or position within the fragment from which the match occurs
        index1 = mergingfrag1.find(merging_substring) # where substring is contained within first fragment
        index2 = mergingfrag2.find(merging_substring) # where substring is contained within the second fragment

        # if matching substring is the begining of the first fragment and NOT the second fragment
        if (index1 == 0)  & (index2 != 0):
            # add the 'leading' charachters of the second fragment before match occurs to the superstring
            superstring = mergingfrag2[0:index2]
            # add matching substring to merging superstring
            superstring += merging_substring

            # if there are additional characthers after matching substring then add them to the merging superstring
            if len(mergingfrag1) != len(merging_substring):
                superstring += mergingfrag1[len(merging_substring):len(mergingfrag1)]
        
        # if matching substring is the beginning of the second fragment and NOT the frist fragment
        elif (index1 != 0) & (index2 == 0):
            # add the 'leading' charachters of the second fragment before match occurs to the superstring
            superstring = mergingfrag1[0:index1]
            # add the matching substring to the merging superstring
            superstring += merging_substring

            # if trailing charachters in merging fragment then add them to superstring
            if len(mergingfrag2) != len(merging_substring):
                superstring += mergingfrag2[len(merging_substring):len(mergingfrag2)]
        
        # if substring is the beginning of BOTH fragments
        elif (index1 == 0) & (index2 == 0):
            
            # superstring will be the matching substring as it is the beginning of both fragments
            superstring = merging_substring

            # if fragment is larger than matching substring add additional charachters to superstring
            if (len(mergingfrag1) > len(merging_substring)):
                superstring += mergingfrag1[len(merging_substring):len(mergingfrag1)]
            
            # if fragment is larger than matching substring add additional charachters to superstring
            if (len(mergingfrag2) > len(merging_substring)):
                superstring += mergingfrag2[len(merging_substring):len(mergingfrag2)]
            

        fragementlist.append(superstring) # add merged fragments (superstring) to fragment list
        fragementlist.remove(mergingfrag1) # remove the merging fragment
        fragementlist.remove(mergingfrag2) # remove the mergning fragment

    # if not matching substring then start concatenating fragments
    else:
        # construct supertring out of the two 'front' fragments in the list
        superstring = fragementlist[0] + fragementlist[1]

        # remove the two merging fragments from the 'front' of the list
        fragementlist.remove(fragementlist[0])
        fragementlist.remove(fragementlist[0])

        # add merged fragments to list
        fragementlist.append(superstring)

    
# display final superstring
print(fragementlist[0])


    
